using System.ComponentModel;

namespace TheCrashedSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the CrashedSaucer class
    /// </summary>
    public class CrashedSaucerUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of CrashedSaucer has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            CrashedSaucer cs = new();
            Assert.Equal("Crashed Saucer", cs.Name);
            Assert.Equal("A stack of crispy french toast smothered in syrup and topped with a pat of butter.", cs.Description);
            Assert.Equal(2u, cs.StackSize);
            Assert.True(cs.Syrup, $"Expected true but found {cs.Syrup}");
            Assert.True(cs.Butter, $"Expected true but found {cs.Butter}");
            Assert.Equal(6.45m, cs.Price);
            Assert.Equal((149u * 2) + 52u + 35u, cs.Calories);
            Assert.Empty(cs.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the name and description does not change
        /// </summary>
        /// <param name="stackSize">The number of french toasts included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butter</param>
        [Theory]
        [InlineData(6, true, true)]
        [InlineData(0, true, true)]
        [InlineData(12, true, true)]
        [InlineData(6, true, false)]
        [InlineData(6, false, false)]
        [InlineData(3, true, false)]
        [InlineData(8, false, false)]
        [InlineData(11, true, true)]
        public void NameDescriptionAlwaysSame(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal("Crashed Saucer", cs.Name);
            Assert.Equal("A stack of crispy french toast smothered in syrup and topped with a pat of butter.", cs.Description);
        }

        /// <summary>
        /// This test verifies that a CrashedSaucer's StackSize cannot exceed 6, and 
        /// if it is attempted, the StackSize will be set to 6.
        /// </summary>
        /// <param name="stackSize">The number of french toasts included</param>
        [Theory]
        [InlineData(6u)]
        [InlineData(7u)]
        [InlineData(8u)]
        [InlineData(9u)]
        [InlineData(10u)]
        [InlineData(100u)]
        [InlineData(10000u)]
        [InlineData(100000u)]
        public void StackSizeNoMoreThanSix(uint stackSize)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize
            };
            Assert.Equal(6u, cs.StackSize);
        }

        /// <summary>
        /// This test verifies that a CrashedSaucer's Price defaults to $6.45,
        /// plus and additional $1.50 for each additional slice beyond the default
        /// </summary>
        /// <param name="stackSize">The number of french toasts included</param>
        /// <param name="price">The total price expected</param>
        /// <param name="decreased">The price of CrashedSaucer instance when one stack size decreased</param>
        /// <param name="increased">The price of CrashedSaucer instance when two stack size increased</param>
        [Theory]
        [InlineData(3, 7.95, 6.45, 9.45)]
        [InlineData(4, 9.45, 7.95, 10.95)]
        [InlineData(5, 10.95, 9.45, 12.45)]
        [InlineData(6, 12.45, 10.95, 12.45)]
        [InlineData(7, 12.45, 10.95, 12.45)]
        [InlineData(8, 12.45, 10.95, 12.45)]
        [InlineData(9, 12.45, 10.95, 12.45)]
        [InlineData(10, 12.45, 10.95, 12.45)]
        public void PriceShouldBeCorrect(uint stackSize, decimal price, decimal decreased, decimal increased)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize
            };
            Assert.Equal(price, cs.Price);
            cs.StackSize--;
            Assert.Equal(decreased, cs.Price);
            cs.StackSize += 2;
            Assert.Equal(increased, cs.Price);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of french toasts included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butters</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, true, true, 149 * 6 + 52 + 35)]
        [InlineData(0, true, true, 149 * 0 + 52 + 35)]
        [InlineData(2, true, true, 149 * 2 + 52 + 35)]
        [InlineData(3, true, false, 149 * 3 + 52 + 0)]
        [InlineData(4, false, false, 149 * 4 + 0 + 0)]
        [InlineData(1, true, false, 149 * 1 + 52 + 0)]
        [InlineData(8, false, false, 149 * 6 + 0 + 0)]
        [InlineData(5, true, true, 149 * 5 + 52 + 35)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool butter, uint calories)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal(calories, cs.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crashed Saucer
        /// </summary>
        /// <param name="stackSize">The number of french toasts included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butters</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(1, true, true, new string[] { "1 slices" })]
        [InlineData(2, false, false, new string[] { "Hold Butter", "Hold Syrup" })]
        [InlineData(2, true, true, new string[] { })]
        [InlineData(3, false, true, new string[] { "3 slices", "Hold Syrup"})]
        [InlineData(4, true, true, new string[] { "4 slices" })]
        [InlineData(5, true, false, new string[] { "5 slices", "Hold Butter"})]
        [InlineData(6, false, false, new string[] { "6 slices", "Hold Butter", "Hold Syrup" })]
        [InlineData(7, true, true, new string[] { "6 slices" })]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool butter, string[] instructions)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an Entree and an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<Entree>(cs);
            Assert.IsAssignableFrom<IMenuItem>(cs);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            CrashedSaucer cs = new();
            Assert.Equal(cs.Name, cs.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cs);
        }

        #endregion
    }
}
