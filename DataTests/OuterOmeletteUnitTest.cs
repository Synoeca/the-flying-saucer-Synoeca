using System.ComponentModel;

namespace TheOuterOmelette.DataTests
{
    /// <summary>
    /// Unit tests for the OuterOmelette class
    /// </summary>
    public class OuterOmeletteUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of OuterOmelette has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            OuterOmelette om = new();
            Assert.Equal("Outer Omelette", om.Name);
            Assert.Equal("A fully loaded Omelette.", om.Description);
            Assert.True(om.CheddarCheese, $"Expected true but found {om.CheddarCheese}");
            Assert.True(om.Peppers, $"Expected true but found {om.Peppers}");
            Assert.True(om.Mushrooms, $"Expected true but found {om.Mushrooms}");
            Assert.True(om.Tomatoes, $"Expected true but found {om.Tomatoes}");
            Assert.True(om.Onions, $"Expected true but found {om.Onions}");
            Assert.Equal(7.45m, om.Price);
            Assert.Equal(94u + 113u + 24u + 4u + 22u + 22u, om.Calories);
            Assert.Empty(om.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the OuterOmelette's state mutates, the name and description does not change
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omelette will be served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette will be served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette will be served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette will be served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(true, true, true, false, true)]
        [InlineData(true, true, false, false, false)]
        [InlineData(false, false, true, true, true)]
        [InlineData(false, true, false, false, true)]
        [InlineData(false, true, false, true, false)]
        [InlineData(false, false, false, false, false)]
        public void NameDescriptionAlwaysSame(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette om = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal("Outer Omelette", om.Name);
            Assert.Equal("A fully loaded Omelette.", om.Description);
        }

        /// <summary>
        /// This test checks that even as the OuterOmelette's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omelette will be served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette will be served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette will be served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette will be served with onions</param>
        /// /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, true, true, true, true, 94u + 113u + 24u + 4u + 22u + 22u)]
        [InlineData(true, true, true, true, false, 94u + 113u + 24u + 4u + 22u)]
        [InlineData(true, true, true, false, true, 94u + 113u + 24u + 4u + 22u)]
        [InlineData(true, true, false, false, false, 94u + 113u + 24u)]
        [InlineData(false, false, true, true, true, 94u + 4u + 22u + 22u)]
        [InlineData(false, true, false, false, true, 94u + 24u + 22u)]
        [InlineData(false, true, false, true, false, 94u + 24u + 22u)]
        [InlineData(false, false, false, false, false, 94u)]
        public void CaloriesShouldBeCorrect(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, uint calories)
        {
            OuterOmelette om = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal(calories, om.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omelette
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omelette will be served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette will be served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette will be served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette will be served with onions</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, new string[] {})]
        [InlineData(true, true, true, true, false, new string[] { "Hold Onions" })]
        [InlineData(true, true, true, false, true, new string[] { "Hold Tomatoes"})]
        [InlineData(true, true, false, false, false, new string[] { "Hold Mushrooms", "Hold Tomatoes", "Hold Onions" })]
        [InlineData(false, false, true, true, true, new string[] { "Hold Cheddar Cheese", "Hold Peppers" })]
        [InlineData(false, true, false, false, true, new string[] { "Hold Cheddar Cheese", "Hold Mushrooms", "Hold Tomatoes" })]
        [InlineData(false, true, false, true, false, new string[] { "Hold Cheddar Cheese", "Hold Mushrooms", "Hold Onions" })]
        [InlineData(false, false, false, false, false, new string[] { "Hold Cheddar Cheese", "Hold Peppers", "Hold Mushrooms", "Hold Tomatoes", "Hold Onions" })]
        public void SpecialInstructionsRelfectsState(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, string[] instructions)
        {
            OuterOmelette om = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, om.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, om.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            OuterOmelette om = new();
            Assert.IsAssignableFrom<Entree>(om);
            Assert.IsAssignableFrom<IMenuItem>(om);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            OuterOmelette om = new();
            Assert.Equal(om.Name, om.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            OuterOmelette om = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(om);
        }

        #endregion
    }
}
