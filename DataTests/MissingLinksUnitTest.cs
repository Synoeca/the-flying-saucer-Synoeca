using System.ComponentModel;

namespace TheMissingLinks.DataTests
{
    /// <summary>
    /// Unit tests for the MissingLinks class
    /// </summary>
    public class MissingLinksUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of MissingLinks has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            MissingLinks ml = new();
            Assert.Equal("Missing Links", ml.Name);
            Assert.Equal("Sizzling pork sausage links.", ml.Description);
            Assert.Equal(2u, ml.Count);
            Assert.Equal(2.00m, ml.Price);
            Assert.Equal(391 * 2u, ml.Calories);
            Assert.Empty(ml.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the name and description does not change
        /// </summary>
        /// <param name="count">The number of link of sausages included</param>
        [Theory]
        [InlineData(0u)]
        [InlineData(1u)]
        [InlineData(2u)]
        [InlineData(3u)]
        [InlineData(7u)]
        [InlineData(8u)]
        [InlineData(9u)]
        [InlineData(10u)]
        public void NameDescriptionAlwaysSame(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal("Missing Links", ml.Name);
            Assert.Equal("Sizzling pork sausage links.", ml.Description);
        }

        /// <summary>
        /// This test verifies that a MissingLinks's link of sausages must be a value between 1 and 8, and 
        /// if it is attempted, the Count will be set to 1 or 8.
        /// </summary>
        /// <param name="count">The number of link of sausages included</param>
        [Theory]
        [InlineData(0u)]
        [InlineData(1u)]
        [InlineData(2u)]
        [InlineData(3u)]
        [InlineData(7u)]
        [InlineData(8u)]
        [InlineData(9u)]
        [InlineData(10u)]
        public void CountShouldBetweenOnetoEight(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            if (count < 1u) Assert.Equal(1u, ml.Count);
            else if (count > 8u) Assert.Equal(8u, ml.Count);
            else Assert.Equal(count, ml.Count);
        }

        /// <summary>
        /// This test verifies that a MissingLinks's Price defaults to $2.00 for 2 link of sausages,
        /// plus and additional $1.00 for each additional or reduced link of sausage
        /// </summary>
        /// <param name="count">The number of link of sausages included</param>
        /// <param name="price">The total price expected</param>
        /// <param name="decreased">The price of TakenBacon instance when one biscuit size decreased</param>
        /// <param name="increased">The price of TakenBacon instance when two biscuit size increased</param>
        [Theory]
        [InlineData(2, 2.00 + 1.00 * 0, 2.00 + 1.00 * 0 - 1.00 * 1, 2.00 + 1.00 * 0 + 1.00 * 1)]
        [InlineData(3, 2.00 + 1.00 * 1, 2.00 + 1.00 * 1 - 1.00 * 1, 2.00 + 1.00 * 1 + 1.00 * 1)]
        [InlineData(4, 2.00 + 1.00 * 2, 2.00 + 1.00 * 2 - 1.00 * 1, 2.00 + 1.00 * 2 + 1.00 * 1)]
        [InlineData(5, 2.00 + 1.00 * 3, 2.00 + 1.00 * 3 - 1.00 * 1, 2.00 + 1.00 * 3 + 1.00 * 1)]
        [InlineData(6, 2.00 + 1.00 * 4, 2.00 + 1.00 * 4 - 1.00 * 1, 2.00 + 1.00 * 4 + 1.00 * 1)]
        [InlineData(7, 2.00 + 1.00 * 5, 2.00 + 1.00 * 5 - 1.00 * 1, 2.00 + 1.00 * 5 + 1.00 * 1)]
        [InlineData(8, 2.00 + 1.00 * 6, 2.00 + 1.00 * 6 - 1.00 * 1, 2.00 + 1.00 * 6)]
        [InlineData(9, 2.00 + 1.00 * 6, 2.00 + 1.00 * 6 - 1.00 * 1, 2.00 + 1.00 * 6)]
        [InlineData(10, 2.00 + 1.00 * 6, 2.00 + 1.00 * 6 - 1.00 * 1, 2.00 + 1.00 * 6)]
        public void PriceShouldBeCorrect(uint count, decimal price, decimal decreased, decimal increased)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(price, ml.Price);
            ml.Count--;
            Assert.Equal(decreased, ml.Price);
            ml.Count += 2;
            Assert.Equal(increased, ml.Price);
        }
        
        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of link of sausages included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(0u, 391u * 1u)]
        [InlineData(1u, 391u * 1u)]
        [InlineData(2u, 391u * 2u)]
        [InlineData(3u, 391u * 3u)]
        [InlineData(4u, 391u * 4u)]
        [InlineData(8u, 391u * 8u)]
        [InlineData(9u, 391u * 8u)]
        [InlineData(10u, 391u * 8u)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(calories, ml.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Missing Links
        /// </summary>
        /// <param name="count">The number of link of sausages included</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(0, new string[] { "1 links" })]
        [InlineData(1, new string[] { "1 links" })]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 links" })]
        [InlineData(4, new string[] { "4 links" })]
        [InlineData(8, new string[] { "8 links" })]
        [InlineData(9, new string[] { "8 links" })]
        [InlineData(10, new string[] { "8 links" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            MissingLinks ml = new()
            {
                Count = count
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ml.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ml.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<Side>(ml);
            Assert.IsAssignableFrom<IMenuItem>(ml);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            MissingLinks ml = new();
            Assert.Equal(ml.Name, ml.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ml);
        }

        #endregion
    }
}
