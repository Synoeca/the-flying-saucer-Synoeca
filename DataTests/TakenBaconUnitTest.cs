using System.ComponentModel;

namespace TheTakenBacon.DataTests
{
    /// <summary>
    /// Unit tests for the TakenBacon class
    /// </summary>
    public class TakenBaconUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of TakenBacon has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            TakenBacon tb = new();
            Assert.Equal("Taken Bacon", tb.Name);
            Assert.Equal("Crispy strips of bacon.", tb.Description);
            Assert.Equal(2u, tb.Count);
            Assert.Equal(2.00m, tb.Price);
            Assert.Equal(86u, tb.Calories);
            Assert.Empty(tb.SpecialInstructions);
        }
        #endregion

        #region state changes
        
        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the name and description does not change
        /// </summary>
        /// <param name="count">The number of strips of bacon included</param>
        [Theory]
        [InlineData(0u)]
        [InlineData(1u)]
        [InlineData(2u)]
        [InlineData(3u)]
        [InlineData(4u)]
        [InlineData(5u)]
        [InlineData(6u)]
        [InlineData(7u)]
        public void NameDescriptionAlwaysSame(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Taken Bacon", tb.Name);
            Assert.Equal("Crispy strips of bacon.", tb.Description);
        }

        /// <summary>
        /// This test verifies that a TakenBacon's strips must be a value between 1 and 6, and 
        /// if it is attempted, the Count will be set to 1 or 6.
        /// </summary>
        /// <param name="count">The number of strips of bacon included</param>
        [Theory]
        [InlineData(0u)]
        [InlineData(1u)]
        [InlineData(2u)]
        [InlineData(3u)]
        [InlineData(6u)]
        [InlineData(7u)]
        [InlineData(8u)]
        [InlineData(9u)]
        public void CountShouldBetweenOnetoSix(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            if (count < 1u) Assert.Equal(1u, tb.Count);
            else if (count > 6u) Assert.Equal(6u, tb.Count);
            else Assert.Equal(count, tb.Count);
        }

        /// <summary>
        /// This test verifies that a TakenBacon's Price defaults to $2.00 for 2 strips of bacon,
        /// plus and additional $1.00 for each additional or reduced strip of bacon
        /// </summary>
        /// <param name="count">The number of strips of bacon included</param>
        /// <param name="price">The total price expected</param>
        /// <param name="decreased">The price of TakenBacon instance when one biscuit size decreased</param>
        /// <param name="increased">The price of TakenBacon instance when two biscuit size increased</param>
        [Theory]
        [InlineData(3, 2.00 + 1.00 * 1, 2.00 + 1.00 * 1 - 1.00 * 1, 2.00 + 1.00 * 1 + 1.00 * 1)]
        [InlineData(4, 2.00 + 1.00 * 2, 2.00 + 1.00 * 2 - 1.00 * 1, 2.00 + 1.00 * 2 + 1.00 * 1)]
        [InlineData(5, 2.00 + 1.00 * 3, 2.00 + 1.00 * 3 - 1.00 * 1, 2.00 + 1.00 * 3 + 1.00 * 1)]
        [InlineData(6, 2.00 + 1.00 * 4, 2.00 + 1.00 * 4 - 1.00 * 1, 2.00 + 1.00 * 4)]
        [InlineData(7, 2.00 + 1.00 * 4, 2.00 + 1.00 * 4 - 1.00 * 1, 2.00 + 1.00 * 4)]
        [InlineData(8, 2.00 + 1.00 * 4, 2.00 + 1.00 * 4 - 1.00 * 1, 2.00 + 1.00 * 4)]
        [InlineData(9, 2.00 + 1.00 * 4, 2.00 + 1.00 * 4 - 1.00 * 1, 2.00 + 1.00 * 4)]
        [InlineData(10, 2.00 + 1.00 * 4, 2.00 + 1.00 * 4 - 1.00 * 1, 2.00 + 1.00 * 4)]
        public void PriceShouldBeCorrect(uint count, decimal price, decimal decreased, decimal increased)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal(price, tb.Price);
            tb.Count--;
            Assert.Equal(decreased, tb.Price);
            tb.Count += 2;
            Assert.Equal(increased, tb.Price);
        }

        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of strips of bacon included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(0u, 43u * 1u)]
        [InlineData(1u, 43u * 1u)]
        [InlineData(2u, 43u * 2u)]
        [InlineData(3u, 43u * 3u)]
        [InlineData(4u, 43u * 4u)]
        [InlineData(5u, 43u * 5u)]
        [InlineData(6u, 43u * 6u)]
        [InlineData(7u, 43u * 6u)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal(calories, tb.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Taken Bacon
        /// </summary>
        /// <param name="count">The number of strips of bacon included</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(0, new string[] { "1 strips" })]
        [InlineData(1, new string[] { "1 strips" })]
        [InlineData(2, new string[] {})]
        [InlineData(3, new string[] { "3 strips" })]
        [InlineData(4, new string[] { "4 strips" })]
        [InlineData(5, new string[] { "5 strips" })]
        [InlineData(6, new string[] { "6 strips" })]
        [InlineData(7, new string[] { "6 strips" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            TakenBacon tb = new()
            {
                Count = count
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, tb.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, tb.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<Side>(tb);
            Assert.IsAssignableFrom<IMenuItem>(tb);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            TakenBacon tb = new();
            Assert.Equal(tb.Name, tb.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tb);
        }

        #endregion
    }
}
