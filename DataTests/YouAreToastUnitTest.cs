using System.ComponentModel;

namespace TheYouAreToast.DataTests
{
    /// <summary>
    /// Unit tests for the YouAreToast class
    /// </summary>
    public class YouAreToastUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of YouAreToast has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            YouAreToast yt = new();
            Assert.Equal("You're Toast", yt.Name);
            Assert.Equal("Texas toast.", yt.Description);
            Assert.Equal(2u, yt.Count);
            Assert.Equal(2.00m, yt.Price);
            Assert.Equal(200u, yt.Calories);
            Assert.Empty(yt.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the name and description does not change
        /// </summary>
        /// <param name="count">The number of slices of toast included</param>
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
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal("You're Toast", yt.Name);
            Assert.Equal("Texas toast.", yt.Description);
        }

        /// <summary>
        /// This test verifies that a YouAreToast's slices must be a value between 1 and 12, and 
        /// if it is attempted, the Count will be set to 1 or 12.
        /// </summary>
        /// <param name="count">The number of slices of toast included</param>
        [Theory]
        [InlineData(0u)]
        [InlineData(1u)]
        [InlineData(2u)]
        [InlineData(3u)]
        [InlineData(6u)]
        [InlineData(11u)]
        [InlineData(12u)]
        [InlineData(13u)]
        public void CountShouldBetweenOnetoTwelve(uint count)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            if (count < 1u) Assert.Equal(1u, yt.Count);
            else if (count > 12u) Assert.Equal(12u, yt.Count);
            else Assert.Equal(count, yt.Count);
        }

        /// <summary>
        /// This test verifies that a YouAreToast's Price defaults to $2.00 for 2 slices of toast,
        /// plus and additional $1.00 for each additional or reduced slice of toast
        /// </summary>
        /// <param name="count">The number of slices of toast included</param>
        /// <param name="price">The total price expected</param>
        /// <param name="decreased">The price of YouAreToast instance when one slice of toast decreased</param>
        /// <param name="increased">The price of YouAreToast instance when two slices of toast increased</param>
        [Theory]
        [InlineData(3, 2.00 + 1.00 * 1, 2.00 + 1.00 * 1 - 1.00 * 1, 2.00 + 1.00 * 1 + 1.00 * 1)]
        [InlineData(4, 2.00 + 1.00 * 2, 2.00 + 1.00 * 2 - 1.00 * 1, 2.00 + 1.00 * 2 + 1.00 * 1)]
        [InlineData(5, 2.00 + 1.00 * 3, 2.00 + 1.00 * 3 - 1.00 * 1, 2.00 + 1.00 * 3 + 1.00 * 1)]
        [InlineData(6, 2.00 + 1.00 * 4, 2.00 + 1.00 * 4 - 1.00 * 1, 2.00 + 1.00 * 4 + 1.00 * 1)]
        [InlineData(7, 2.00 + 1.00 * 5, 2.00 + 1.00 * 5 - 1.00 * 1, 2.00 + 1.00 * 5 + 1.00 * 1)]
        [InlineData(8, 2.00 + 1.00 * 6, 2.00 + 1.00 * 6 - 1.00 * 1, 2.00 + 1.00 * 6 + 1.00 * 1)]
        [InlineData(9, 2.00 + 1.00 * 7, 2.00 + 1.00 * 7 - 1.00 * 1, 2.00 + 1.00 * 7 + 1.00 * 1)]
        [InlineData(10, 2.00 + 1.00 * 8, 2.00 + 1.00 * 8 - 1.00 * 1, 2.00 + 1.00 * 8 + 1.00 * 1)]
        [InlineData(11, 2.00 + 1.00 * 9, 2.00 + 1.00 * 9 - 1.00 * 1, 2.00 + 1.00 * 9 + 1.00 * 1)]
        [InlineData(12, 2.00 + 1.00 * 10, 2.00 + 1.00 * 10 - 1.00 * 1, 2.00 + 1.00 * 10)]
        [InlineData(13, 2.00 + 1.00 * 10, 2.00 + 1.00 * 10 - 1.00 * 1, 2.00 + 1.00 * 10)]
        [InlineData(14, 2.00 + 1.00 * 10, 2.00 + 1.00 * 10 - 1.00 * 1, 2.00 + 1.00 * 10)]
        public void PriceShouldBeCorrect(uint count, decimal price, decimal decreased, decimal increased)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal(price, yt.Price);
            yt.Count--;
            Assert.Equal(decreased, yt.Price);
            yt.Count += 2;
            Assert.Equal(increased, yt.Price);
        }

        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of slices of toast included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(0u, 100u * 1u)]
        [InlineData(1u, 100u * 1u)]
        [InlineData(2u, 100u * 2u)]
        [InlineData(3u, 100u * 3u)]
        [InlineData(6u, 100u * 6u)]
        [InlineData(11u, 100u * 11u)]
        [InlineData(12u, 100u * 12u)]
        [InlineData(13u, 100u * 12u)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal(calories, yt.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the You Are Toast
        /// </summary>
        /// <param name="count">The number of slices of toast included</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(0, new string[] { "1 slices" })]
        [InlineData(1, new string[] { "1 slices" })]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 slices" })]
        [InlineData(6, new string[] { "6 slices" })]
        [InlineData(11, new string[] { "11 slices" })]
        [InlineData(12, new string[] { "12 slices" })]
        [InlineData(13, new string[] { "12 slices" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            YouAreToast yt = new()
            {
                Count = count
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, yt.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, yt.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            YouAreToast yt = new();
            Assert.IsAssignableFrom<Side>(yt);
            Assert.IsAssignableFrom<IMenuItem>(yt);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            YouAreToast yt = new();
            Assert.Equal(yt.Name, yt.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            YouAreToast yt = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(yt);
        }

        #endregion
    }
}
