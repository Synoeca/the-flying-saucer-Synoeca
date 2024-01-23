using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInorganicSubstance.DataTests
{
    /// <summary>
    /// Unit tests for the InorganicSubstance class
    /// </summary>
    public class InorganicSubstanceUnitTest
    {
        #region default values

        /// <summary>
        /// This test checks that the new instance of Inorganic Substance has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            InorganicSubstance os = new();
            Assert.Equal("Inorganic Substance", os.Name);
            Assert.Equal("A cold glass of ice water.", os.Description);
            Assert.Equal(ServingSize.Small, os.Size);
            Assert.True(os.Ice, $"Expected true but found {os.Ice}");
            Assert.Equal(0.00m, os.Price);
            Assert.Equal(0u, os.Calories);
            Assert.Empty(os.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the InorganicSubstance's state mutates, the name and description does not change
        /// </summary>
        /// <param name="size">The size of drink offered</param>
        /// <param name="ice">If the Inorganic Substance will be served with ice</param>
        [Theory]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Small, false)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Medium, false)]
        [InlineData(ServingSize.Large, true)]
        [InlineData(ServingSize.Large, false)]
        public void NameDescriptionAlwaysSame(ServingSize size, bool ice)
        {
            InorganicSubstance os = new()
            {
                Size = size,
                Ice = ice
            };
            Assert.Equal("Inorganic Substance", os.Name);
            Assert.Equal("A cold glass of ice water.", os.Description);
        }

        /// <summary>
        /// This test verifies that a InorganicSubstance's Price defaults to
        /// $0.00 for small, $0.00 for medium, $0.00 for large
        /// </summary>
        /// <param name="size">The size of InorganicSubstance instance</param>
        /// <param name="first">The initial price of InorganicSubstance instance</param>
        /// <param name="second">The price of InorganicSubstance instance when the increment in ServingSize occurs once.</param>
        /// <param name="third">The price of InorganicSubstance instance when the increase in ServingSize occurs twice</param>
        [Theory]
        [InlineData(ServingSize.Small, 0.00, 0.00, 0.00)]
        [InlineData(ServingSize.Medium, 0.00, 0.00, 0.00)]
        [InlineData(ServingSize.Large, 0.00, 0.00, 0.00)]
        public void PriceShouldBeCorrect(ServingSize size, decimal first, decimal second, decimal third)
        {
            InorganicSubstance os = new()
            {
                Size = size!
            };

            Assert.Equal(first, os.Price);
            if (os.Size == ServingSize.Large) os.Size = ServingSize.Small;
            else os.Size++;

            Assert.Equal(second, os.Price);
            if (os.Size == ServingSize.Large) os.Size = ServingSize.Small;
            else os.Size++;

            Assert.Equal(third, os.Price);
        }

        /// <summary>
        /// This test verifies that a InorganicSubstance's calories
        /// 0 for small, 0 for medium, 0 for large
        /// </summary>
        /// <param name="size">The size of InorganicSubstance instance</param>
        /// <param name="first">The initial calories of InorganicSubstance instance</param>
        /// <param name="second">The calories of InorganicSubstance instance when the increment in ServingSize occurs once.</param>
        /// <param name="third">The calories of InorganicSubstance instance when the increment in ServingSize occurs twice</param>
        [Theory]
        [InlineData(ServingSize.Small, 0u, 0u, 0u)]
        [InlineData(ServingSize.Medium, 0u, 0u, 0u)]
        [InlineData(ServingSize.Large, 0u, 0u, 0u)]
        public void CaloriesShouldBeCorrect(ServingSize size, uint first, uint second, uint third)
        {
            InorganicSubstance os = new()
            {
                Size = size
            };

            Assert.Equal(first, os.Calories);
            if (os.Size == ServingSize.Large) os.Size = ServingSize.Small;
            else os.Size++;

            Assert.Equal(second, os.Calories);
            if (os.Size == ServingSize.Large) os.Size = ServingSize.Small;
            else os.Size++;

            Assert.Equal(third, os.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Inorganic Substance
        /// </summary>
        /// <param name="ice">If the Inorganic Substance will be served with ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "No Ice" })]
        public void SpecialInstructionsRelfectsState(bool ice, string[] instructions)
        {
            InorganicSubstance os = new()
            {
                Ice = ice
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, os.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, os.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to the Drink and the IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            InorganicSubstance os = new();
            Assert.IsAssignableFrom<Drink>(os);
            Assert.IsAssignableFrom<IMenuItem>(os);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            InorganicSubstance os = new();
            Assert.Equal(os.Name, os.ToString());
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

        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            InorganicSubstance os = new();
            Assert.PropertyChanged(os, propertyName, () => {
                os.Size = size;
            });
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            InorganicSubstance os = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(os);
        }

        #endregion
    }
}
