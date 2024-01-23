using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheLiquifiedVegetation.DataTests
{
    /// <summary>
    /// Unit tests for the LiquifiedVegetation class
    /// </summary>
    public class LiquifiedVegetationUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of Liquified Vegetation has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            LiquifiedVegetation lv = new();
            Assert.Equal("Liquified Vegetation", lv.Name);
            Assert.Equal("A cold glass of blended vegetable juice.", lv.Description);
            Assert.Equal(ServingSize.Small, lv.Size);
            Assert.True(lv.Ice, $"Expected true but found {lv.Ice}");
            Assert.Equal(1.00m, lv.Price);
            Assert.Equal(72u, lv.Calories);
            Assert.Empty(lv.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the LiquifiedVegetation's state mutates, the name and description does not change
        /// </summary>
        /// <param name="size">The size of drink offered</param>
        /// <param name="ice">If the Liquified Vegetation will be served with ice</param>
        [Theory]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Small, false)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Medium, false)]
        [InlineData(ServingSize.Large, true)]
        [InlineData(ServingSize.Large, false)]
        public void NameDescriptionAlwaysSame(ServingSize size, bool ice)
        {
            LiquifiedVegetation lv = new()
            {
                Size = size,
                Ice = ice
            };
            Assert.Equal("Liquified Vegetation", lv.Name);
            Assert.Equal("A cold glass of blended vegetable juice.", lv.Description);
        }

        /// <summary>
        /// This test verifies that a LiquifiedVegetation's Price defaults to
        /// $1.00 for small, $1.50 for medium, $2.00 for large
        /// </summary>
        /// <param name="size">The size of LiquifiedVegetation instance</param>
        /// <param name="first">The initial price of LiquifiedVegetation instance</param>
        /// <param name="second">The price of LiquifiedVegetation instance when the increment in ServingSize occurs once.</param>
        /// <param name="third">The price of LiquifiedVegetation instance when the increase in ServingSize occurs twice</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00, 1.50, 2.00)]
        [InlineData(ServingSize.Medium, 1.50, 2.00, 1.00)]
        [InlineData(ServingSize.Large, 2.00, 1.00, 1.50)]
        public void PriceShouldBeCorrect(ServingSize size, decimal first, decimal second, decimal third)
        {
            LiquifiedVegetation lv = new()
            {
                Size = size!
            };

            Assert.Equal(first, lv.Price);
            if (lv.Size == ServingSize.Large) lv.Size = ServingSize.Small;
            else lv.Size++;

            Assert.Equal(second, lv.Price);
            if (lv.Size == ServingSize.Large) lv.Size = ServingSize.Small;
            else lv.Size++;

            Assert.Equal(third, lv.Price);
        }

        /// <summary>
        /// This test verifies that a LiquifiedVegetation's calories
        /// 72 for small, 144 for medium, 216 for large
        /// </summary>
        /// <param name="size">The size of LiquifiedVegetation instance</param>
        /// <param name="first">The initial calories of LiquifiedVegetation instance</param>
        /// <param name="second">The calories of LiquifiedVegetation instance when the increment in ServingSize occurs once.</param>
        /// <param name="third">The calories of LiquifiedVegetation instance when the increment in ServingSize occurs twice</param>
        [Theory]
        [InlineData(ServingSize.Small, 72u, 144u, 216u)]
        [InlineData(ServingSize.Medium, 144u, 216u, 72u)]
        [InlineData(ServingSize.Large, 216u, 72u, 144u)]
        public void CaloriesShouldBeCorrect(ServingSize size, uint first, uint second, uint third)
        {
            LiquifiedVegetation lv = new()
            {
                Size = size!
            };

            Assert.Equal(first, lv.Calories);
            if (lv.Size == ServingSize.Large) lv.Size = ServingSize.Small;
            else lv.Size++;

            Assert.Equal(second, lv.Calories);
            if (lv.Size == ServingSize.Large) lv.Size = ServingSize.Small;
            else lv.Size++;

            Assert.Equal(third, lv.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Liquified Vegetation
        /// </summary>
        /// <param name="ice">If the Liquified Vegetation will be served with ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] {})]
        [InlineData(false, new string[] { "No Ice" })]
        public void SpecialInstructionsRelfectsState(bool ice, string[] instructions)
        {
            LiquifiedVegetation lv = new()
            {
                Ice = ice
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lv.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lv.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to the Drink and the IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<Drink>(lv);
            Assert.IsAssignableFrom<IMenuItem>(lv);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            LiquifiedVegetation lv = new();
            Assert.Equal(lv.Name, lv.ToString());
        }

        /// <summary>
        /// Checks that the property does indeed change
        /// </summary>
        /// <param name="size">The Serving size of item</param>
        /// <param name="propertyName">The name of the property to test</param>
        [Theory]
        [InlineData(ServingSize.Small, "Size")]
        [InlineData(ServingSize.Medium, "Size")]
        [InlineData(ServingSize.Large, "Size")]
        [InlineData(ServingSize.Small, "Price")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Small, "Calories")]
        [InlineData(ServingSize.Medium, "Calories")]
        [InlineData(ServingSize.Large, "Calories")]

        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            LiquifiedVegetation lv = new();
            Assert.PropertyChanged(lv, propertyName, () => {
                lv.Size = size;
            });
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(lv);
        }

        #endregion
    }
}
