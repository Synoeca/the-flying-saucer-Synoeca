using System.ComponentModel;

namespace TheCropCircle.DataTests
{
    /// <summary>
    /// Unit tests for the CropCircle class
    /// </summary>
    public class CropCircleUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of CropCircle has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            CropCircle cr = new();
            Assert.Equal("Crop Circle", cr.Name);
            Assert.Equal("Oatmeal topped with mixed berries.", cr.Description);
            Assert.True(cr.Berries, $"Expected true but found {cr.Berries}");
            Assert.Equal(2.00m, cr.Price);
            Assert.Equal(158u + 89u, cr.Calories);
            Assert.Empty(cr.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the name and description does not change
        /// </summary>
        /// <param name="berries">If the Crop Circle will be served with berries</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameDescriptionAlwaysSame(bool berries)
        {
            CropCircle cr = new()
            {
                Berries = berries
            };
            Assert.Equal("Crop Circle", cr.Name);
            Assert.Equal("Oatmeal topped with mixed berries.", cr.Description);
        }

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="berries">If the Crop Circle will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, 158u + 89u)]
        [InlineData(false, 158u)]
        public void CaloriesShouldBeCorrect(bool berries, uint calories)
        {
            CropCircle cr = new()
            {
                Berries = berries
            };
            Assert.Equal(calories, cr.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crop Circle
        /// </summary>
        /// <param name="berries">If the Crop Circle will be served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "Hold Berries" })]
        public void SpecialInstructionsRelfectsState(bool berries, string[] instructions)
        {
            CropCircle cr = new()
            {
                Berries = berries
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cr.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cr.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            CropCircle cr = new();
            Assert.IsAssignableFrom<Side>(cr);
            Assert.IsAssignableFrom<IMenuItem>(cr);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            CropCircle cr = new();
            Assert.Equal(cr.Name, cr.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CropCircle cr = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cr);
        }

        #endregion
    }
}
