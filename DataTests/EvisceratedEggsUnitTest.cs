using System.ComponentModel;

namespace TheEvisceratedEggs.DataTests
{
    /// <summary>
    /// Unit tests for the EvisceratedEggs class
    /// </summary>
    public class EvisceratedEggsUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of EvisceratedEggs has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            EvisceratedEggs eg = new();
            Assert.Equal("Eviscerated Eggs", eg.Name);
            Assert.Equal("Eggs prepared the way you like.", eg.Description);
            Assert.Equal(EggStyle.OverEasy, eg.Style);
            Assert.Equal(2u, eg.Count);
            Assert.Equal(2.00m, eg.Price);
            Assert.Equal(156u, eg.Calories);
            Assert.Contains("Over Easy", eg.SpecialInstructions);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the name and description does not change
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="style">The style of the EvisceratedEggs instance</param>
        [Theory]
        [InlineData(0u, EggStyle.OverEasy)]
        [InlineData(1u, EggStyle.HardBoiled)]
        [InlineData(2u, EggStyle.Poached)]
        [InlineData(3u, EggStyle.Scrambled)]
        [InlineData(4u, EggStyle.SoftBoiled)]
        [InlineData(5u, EggStyle.SunnySideUp)]
        [InlineData(6u, EggStyle.HardBoiled)]
        [InlineData(7u, EggStyle.OverEasy)]
        public void NameDescriptionAlwaysSame(uint count, EggStyle style)
        {
            EvisceratedEggs eg = new()
            {
                Count = count,
                Style = style
            };
            Assert.Equal("Eviscerated Eggs", eg.Name);
            Assert.Equal("Eggs prepared the way you like.", eg.Description);
        }

        /// <summary>
        /// This test verifies that a EvisceratedEggs's Style property has been correctly modified
        /// </summary>
        /// <param name="style">The style of the EvisceratedEggs instance</param>
        [Theory]
        [InlineData(EggStyle.OverEasy)]
        [InlineData(EggStyle.HardBoiled)]
        [InlineData(EggStyle.Poached)]
        [InlineData(EggStyle.Scrambled)]
        [InlineData(EggStyle.SoftBoiled)]
        [InlineData(EggStyle.SunnySideUp)]
        public void EggStyleShouldBeCorrect(EggStyle style)
        {
            EvisceratedEggs eg = new()
            {
                Style = style
            };
            Assert.Equal(style, eg.Style);
        }

        /// <summary>
        /// This test verifies that a EvisceratedEggs's eggs must be a value between 1 and 6, and 
        /// if it is attempted, the Count will be set to 1 or 6.
        /// </summary>
        /// <param name="count">The number of eggs included</param>
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
            EvisceratedEggs eg = new()
            {
                Count = count
            };
            if (count < 1u) Assert.Equal(1u, eg.Count);
            else if (count > 6u) Assert.Equal(6u, eg.Count);
            else Assert.Equal(count, eg.Count);
        }

        /// <summary>
        /// This test verifies that a EvisceratedEggs's Price defaults to $2.00 for 2 eggs,
        /// plus and additional $1.00 for each additional or reduced number of eggs
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="price">The total price expected</param>
        /// <param name="decreased">The price of EvisceratedEggs instance when one number of egg decreased</param>
        /// <param name="increased">The price of EvisceratedEggs instance when two number of eggs increased</param>
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
            EvisceratedEggs eg = new()
            {
                Count = count
            };
            Assert.Equal(price, eg.Price);
            eg.Count--;
            Assert.Equal(decreased, eg.Price);
            eg.Count += 2;
            Assert.Equal(increased, eg.Price);
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of number of eggs included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(0u, 78u * 1u)]
        [InlineData(1u, 78u * 1u)]
        [InlineData(2u, 78u * 2u)]
        [InlineData(3u, 78u * 3u)]
        [InlineData(4u, 78u * 4u)]
        [InlineData(5u, 78u * 5u)]
        [InlineData(6u, 78u * 6u)]
        [InlineData(7u, 78u * 6u)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            EvisceratedEggs eg = new()
            {
                Count = count
            };
            Assert.Equal(calories, eg.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Taken Bacon
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="style">The style of the EvisceratedEggs instance</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(0, EggStyle.OverEasy, new string[] { "1 eggs", "Over Easy" })]
        [InlineData(1, EggStyle.HardBoiled, new string[] { "1 eggs", "Hard Boiled" })]
        [InlineData(2, EggStyle.Poached, new string[] { "Poached" })]
        [InlineData(3, EggStyle.Scrambled, new string[] { "3 eggs", "Scrambled" })]
        [InlineData(4, EggStyle.SoftBoiled, new string[] { "4 eggs", "Soft Boiled" })]
        [InlineData(5, EggStyle.SunnySideUp, new string[] { "5 eggs", "Sunny Side Up" })]
        [InlineData(6, EggStyle.OverEasy, new string[] { "6 eggs", "Over Easy" })]
        [InlineData(7, EggStyle.HardBoiled, new string[] { "6 eggs", "Hard Boiled" })]
        public void SpecialInstructionsRelfectsState(uint count, EggStyle style, string[] instructions)
        {
            EvisceratedEggs eg = new()
            {
                Count = count,
                Style = style
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, eg.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, eg.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            EvisceratedEggs eg = new();
            Assert.IsAssignableFrom<Side>(eg);
            Assert.IsAssignableFrom<IMenuItem>(eg);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            EvisceratedEggs eg = new();
            Assert.Equal(eg.Name, eg.ToString());
        }

        /// <summary>
        /// Checks that the property does indeed change
        /// </summary>
        /// <param name="style">The egg style of item</param>
        /// <param name="propertyName">The name of the property to test</param>
        [Theory]
        [InlineData(EggStyle.HardBoiled, "Style")]
        [InlineData(EggStyle.OverEasy, "Style")]
        [InlineData(EggStyle.Poached, "Style")]
        [InlineData(EggStyle.Scrambled, "Style")]
        [InlineData(EggStyle.SoftBoiled, "Style")]
        [InlineData(EggStyle.SunnySideUp, "Style")]

        public void ChangingSizeShouldNotifyOfPropertyChanges(EggStyle style, string propertyName)
        {
            EvisceratedEggs eg = new();
            Assert.PropertyChanged(eg, propertyName, () => {
                eg.Style = style;
            });
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            EvisceratedEggs eg = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(eg);
        }

        #endregion
    }
}
