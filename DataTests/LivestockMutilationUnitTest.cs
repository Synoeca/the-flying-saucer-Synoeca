using System.ComponentModel;

namespace TheLivestockMutilation.DataTests
{
    /// <summary>
    /// Unit tests for the LivestockMutilation class
    /// </summary>
    public class LivestockMutilationUnitTest
    {
        #region default values

        /// <summary>
        /// This test checks that the new instance of LivestockMutilation has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            LivestockMutilation lm = new();
            Assert.Equal("Livestock Mutilation", lm.Name);
            Assert.Equal("A hearty serving of biscuits, smothered in sausage-laden gravy.", lm.Description);
            Assert.Equal(3u, lm.Biscuits);
            Assert.True(lm.Gravy, $"Expected true but found {lm.Gravy}");
            Assert.Equal(7.25m, lm.Price);
            Assert.Equal((49 * 3u) + 140u, lm.Calories);
            Assert.Empty(lm.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the name and description does not change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with whipped cream</param>
        [Theory]
        [InlineData(6, true)]
        [InlineData(0, true)]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(3, true)]
        [InlineData(8, false)]
        [InlineData(2, true)]
        public void NameDescriptionAlwaysSame(uint biscuits, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            Assert.Equal("Livestock Mutilation", lm.Name);
            Assert.Equal("A hearty serving of biscuits, smothered in sausage-laden gravy.", lm.Description);
        }

        /// <summary>
        /// This test verifies that a LivestockMutilation's Biscuits cannot exceed 8, and 
        /// if it is attempted, the Biscuits will be set to 8.
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        [Theory]
        [InlineData(8u)]
        [InlineData(9u)]
        [InlineData(10u)]
        [InlineData(11u)]
        [InlineData(12u)]
        [InlineData(100u)]
        [InlineData(10000u)]
        [InlineData(100000u)]
        public void BiscuitsNoMoreThanEight(uint biscuits)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits
            };
            Assert.Equal(8u, lm.Biscuits);
        }

        /// <summary>
        /// This test verifies that a LivestockMutilation's Price defaults to $7.25,
        /// plus and additional $1.00 for each additional biscuit beyond the default
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="price">The total price expected</param>
        /// <param name="decreased">The price of LivestockMutilation instance when one biscuit size decreased</param>
        /// <param name="increased">The price of LivestockMutilation instance when two biscuit size increased</param>
        [Theory]
        [InlineData(4, 7.25 + 1.00 * 1, 7.25 + 1.00 * 1 - 1.00 * 1, 7.25 + 1.00 * 1 + 1.00 * 1)]
        [InlineData(5, 7.25 + 1.00 * 2, 7.25 + 1.00 * 2 - 1.00 * 1, 7.25 + 1.00 * 2 + 1.00 * 1)]
        [InlineData(6, 7.25 + 1.00 * 3, 7.25 + 1.00 * 3 - 1.00 * 1, 7.25 + 1.00 * 3 + 1.00 * 1)]
        [InlineData(7, 7.25 + 1.00 * 4, 7.25 + 1.00 * 4 - 1.00 * 1, 7.25 + 1.00 * 4 + 1.00 * 1)]
        [InlineData(8, 7.25 + 1.00 * 5, 7.25 + 1.00 * 5 - 1.00 * 1, 7.25 + 1.00 * 5)]
        [InlineData(9, 7.25 + 1.00 * 5, 7.25 + 1.00 * 5 - 1.00 * 1, 7.25 + 1.00 * 5)]
        [InlineData(10, 7.25 + 1.00 * 5, 7.25 + 1.00 * 5 - 1.00 * 1, 7.25 + 1.00 * 5)]
        [InlineData(11, 7.25 + 1.00 * 5, 7.25 + 1.00 * 5 - 1.00 * 1, 7.25 + 1.00 * 5)]
        public void PriceShouldBeCorrect(uint biscuits, decimal price, decimal decreased, decimal increased)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits
            };
            Assert.Equal(price, lm.Price);
            lm.Biscuits--;
            Assert.Equal(decreased, lm.Price);
            lm.Biscuits += 2;
            Assert.Equal(increased, lm.Price);
        }

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(2u, true, 49u * 2u + 140u)]
        [InlineData(3u, false, 49u * 3u)]
        [InlineData(4u, true, 49u * 4u + 140u)]
        [InlineData(5u, true, 49u * 5u + 140u)]
        [InlineData(6u, false, 49u * 6u + 0u)]
        [InlineData(7u, true, 49u * 7u + 140u)]
        [InlineData(8u, false, 49u * 8u + 0u)]
        [InlineData(9u, true, 49u * 8u + 140u)]
        public void CaloriesShouldBeCorrect(uint biscuits, bool gravy, uint calories)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            Assert.Equal(calories, lm.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Livestock Mutilation
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with syrup</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, true, new string[] { "2 biscuits" })]
        [InlineData(3, true, new string[] {})]
        [InlineData(4, true, new string[] { "4 biscuits" })]
        [InlineData(5, false, new string[] { "5 biscuits", "Hold Gravy" })]
        [InlineData(6, true, new string[] { "6 biscuits" })]
        [InlineData(7, true, new string[] { "7 biscuits"})]
        [InlineData(8, false, new string[] { "8 biscuits", "Hold Gravy"})]
        [InlineData(9, true, new string[] { "8 biscuits" })]
        public void SpecialInstructionsRelfectsState(uint biscuits, bool gravy, string[] instructions)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lm.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an Entree and an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<Entree>(lm);
            Assert.IsAssignableFrom<IMenuItem>(lm);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            LivestockMutilation lm = new();
            Assert.Equal(lm.Name, lm.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(lm);
        }

        #endregion
    }
}
