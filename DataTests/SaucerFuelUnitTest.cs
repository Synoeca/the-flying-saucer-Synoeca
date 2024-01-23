using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSaucerFuel.DataTests
{
    /// <summary>
    /// Unit tests for the SaucerFuel class
    /// </summary>
    public class SaucerFuelUnitTest
    {
        #region default values

        /// <summary>
        /// This test checks that the new instance of Saucer Fuel has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            SaucerFuel sf = new();
            Assert.Equal("Saucer Fuel", sf.Name);
            Assert.Equal("A steaming cup of coffee.", sf.Description);
            Assert.Equal(ServingSize.Small, sf.Size);
            Assert.False(sf.Decaf, $"Expected false but found {sf.Decaf}");
            Assert.False(sf.Cream, $"Expected false but found {sf.Cream}");
            Assert.Equal(1.00m, sf.Price);
            Assert.Equal(1u, sf.Calories);
            Assert.Empty(sf.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the name and description will be a expected state
        /// </summary>
        /// <param name="size">The size of drink offered</param>
        /// <param name="decaf">If the Saucer Fuel will be served with decaf</param>
        /// <param name="cream">If the Saucer Fuel will be served with cream</param>
        [Theory]
        [InlineData(ServingSize.Small, true, true)]
        [InlineData(ServingSize.Small, true, false)]
        [InlineData(ServingSize.Small, false, false)]
        [InlineData(ServingSize.Medium, true, true)]
        [InlineData(ServingSize.Medium, true, false)]
        [InlineData(ServingSize.Medium, false, true)]
        [InlineData(ServingSize.Large, true, true)]
        [InlineData(ServingSize.Large, true, false)]
        [InlineData(ServingSize.Large, false, false)]
        public void NameDescriptionShouldBeCorrect(ServingSize size, bool decaf, bool cream)
        {
            SaucerFuel sf = new()
            {
                Size = size,
                Decaf = decaf,
                Cream = cream
            };
            if (!decaf) Assert.Equal("Saucer Fuel", sf.Name);
            else Assert.Equal("Decaf Saucer Fuel", sf.Name);
            Assert.Equal("A steaming cup of coffee.", sf.Description);
        }

        /// <summary>
        /// This test verifies that a SaucerFuel's Price defaults to
        /// $1.00 for small, $1.50 for medium, $2.00 for large
        /// </summary>
        /// <param name="size">The size of SaucerFuel instance</param>
        /// <param name="first">The initial price of SaucerFuel instance</param>
        /// <param name="second">The price of SaucerFuel instance when the increment in ServingSize occurs once.</param>
        /// <param name="third">The price of SaucerFuel instance when the increase in ServingSize occurs twice</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00, 1.50, 2.00)]
        [InlineData(ServingSize.Medium, 1.50, 2.00, 1.00)]
        [InlineData(ServingSize.Large, 2.00, 1.00, 1.50)]
        public void PriceShouldBeCorrect(ServingSize size, decimal first, decimal second, decimal third)
        {
            SaucerFuel sf = new()
            {
                Size = size
            };

            Assert.Equal(first, sf.Price);
            if (sf.Size == ServingSize.Large) sf.Size = ServingSize.Small;
            else sf.Size++;

            Assert.Equal(second, sf.Price);
            if (sf.Size == ServingSize.Large) sf.Size = ServingSize.Small;
            else sf.Size++;

            Assert.Equal(third, sf.Price);
        }

        /// <summary>
        /// This test verifies that a SaucerFuel's calories
        /// 72 for small, 144 for medium, 216 for large 
        /// </summary>
        /// <param name="size">The size of SaucerFuel instance</param>
        /// <param name="cream">If the Saucer Fuel will be served with cream</param>
        /// <param name="first">The initial calories of SaucerFuel instance</param>
        /// <param name="second">The calories of SaucerFuel instance when the increment in ServingSize occurs once.</param>
        /// <param name="third">The calories of SaucerFuel instance when the increment in ServingSize occurs twice</param>
        [Theory]
        [InlineData(ServingSize.Small, true, 29u+1u, 29u + 2u, 29u + 3u)]
        [InlineData(ServingSize.Small, false, 1u, 2u, 3u)]
        [InlineData(ServingSize.Medium, true, 29u + 2u, 29u + 3u, 29u + 1u)]
        [InlineData(ServingSize.Medium, false, 2u, 3u, 1u)]
        [InlineData(ServingSize.Large, true, 29u + 3u, 29u + 1u, 29u + 2u)]
        [InlineData(ServingSize.Large, false, 3u, 1u, 2u)]
        public void CaloriesShouldBeCorrect(ServingSize size, bool cream, uint first, uint second, uint third)
        {
            SaucerFuel sf = new()
            {
                Size = size,
                Cream = cream
            };

            Assert.Equal(first, sf.Calories);
            if (sf.Size == ServingSize.Large) sf.Size = ServingSize.Small;
            else sf.Size++;

            Assert.Equal(second, sf.Calories);
            if (sf.Size == ServingSize.Large) sf.Size = ServingSize.Small;
            else sf.Size++;

            Assert.Equal(third, sf.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Saucer Fuel
        /// </summary>
        /// <param name="decaf">If the Saucer Fuel will be served with decaf</param>
        /// <param name="cream">If the Saucer Fuel will be served with cream</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, new string[] { "With Cream" })]
        [InlineData(true, false, new string[] { })]
        [InlineData(false, true, new string[] { "With Cream" })]
        [InlineData(false, false, new string[] { })]
        public void SpecialInstructionsRelfectsState(bool decaf, bool cream, string[] instructions)
        {
            SaucerFuel sf = new()
            {
                Decaf = decaf,
                Cream = cream
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, sf.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, sf.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to the Drink and the IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<Drink>(sf);
            Assert.IsAssignableFrom<IMenuItem>(sf);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            SaucerFuel sf = new();
            Assert.Equal(sf.Name, sf.ToString());
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
            SaucerFuel sf = new();
            Assert.PropertyChanged(sf, propertyName, () => {
                sf.Size = size;
            });
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(sf);
        }

        #endregion
    }
}
