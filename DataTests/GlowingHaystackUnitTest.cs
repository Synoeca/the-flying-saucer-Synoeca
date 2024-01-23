using System.ComponentModel;
using System.IO;

namespace TheGlowingHaystack.DataTests
{
    /// <summary>
    /// Unit tests for the GlowingHaystack class
    /// </summary>
    public class GlowingHaystackUnitTest
    {
        #region default values
        /// <summary>
        /// This test checks that the new instance of GlowingHaystack has the default starting value for every property.
        /// </summary>
        [Fact]
        public void HasDefaultStartingValue()
        {
            GlowingHaystack gh = new();
            Assert.Equal("Glowing Haystack", gh.Name);
            Assert.Equal("Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.", gh.Description);
            Assert.True(gh.GreenChileSauce, $"Expected true but found {gh.GreenChileSauce}");
            Assert.True(gh.SourCream, $"Expected true but found {gh.SourCream}");
            Assert.True(gh.Tomatoes, $"Expected true but found {gh.Tomatoes}");
            Assert.Equal(2.00m, gh.Price);
            Assert.Equal(470u + 15u + 23u + 22u, gh.Calories);
            Assert.Empty(gh.SpecialInstructions);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the name and description does not change
        /// </summary>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="sourCream">If the Glowing Haystack will be served with green sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, false, true)]
        [InlineData(false, true, false)]
        [InlineData(false, true, true)]
        [InlineData(false, false, false)]
        public void NameDescriptionAlwaysSame(bool greenChileSauce, bool sourCream, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes
            };
            Assert.Equal("Glowing Haystack", gh.Name);
            Assert.Equal("Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.", gh.Description);
        }

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="sourCream">If the Glowing Haystack will be served with green sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, true, true, 470u + 15u + 23u + 22u)]
        [InlineData(true, true, false, 470u + 15u + 23u)]
        [InlineData(true, false, true, 470u + 15u + 22u)]
        [InlineData(true, false, false, 470u + 15u)]
        [InlineData(false, false, true, 470u + 22u)]
        [InlineData(false, true, false, 470u + 23u)]
        [InlineData(false, true, true, 470u + 23u + 22u)]
        [InlineData(false, false, false, 470u)]
        public void CaloriesShouldBeCorrect(bool greenChileSauce, bool sourCream, bool tomatoes, uint calories)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes
            };
            Assert.Equal(calories, gh.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Glowing Haystack
        /// </summary>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="sourCream">If the Glowing Haystack will be served with green sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, new string[] {})]
        [InlineData(true, true, false, new string[] { "Hold Tomatoes" })]
        [InlineData(true, false, true, new string[] { "Hold Sour Cream" })]
        [InlineData(true, false, false, new string[] { "Hold Sour Cream", "Hold Tomatoes" })]
        [InlineData(false, false, true, new string[] { "Hold Green Chile Sauce", "Hold Sour Cream" })]
        [InlineData(false, true, false, new string[] { "Hold Green Chile Sauce", "Hold Tomatoes" })]
        [InlineData(false, true, true, new string[] { "Hold Green Chile Sauce" })]
        [InlineData(false, false, false, new string[] { "Hold Green Chile Sauce", "Hold Sour Cream", "Hold Tomatoes" })]
        public void SpecialInstructionsRelfectsState(bool greenChileSauce, bool sourCream, bool tomatoes, string[] instructions)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes
            };

            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, gh.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<Side>(gh);
            Assert.IsAssignableFrom<IMenuItem>(gh);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            GlowingHaystack gh = new();
            Assert.Equal(gh.Name, gh.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(gh);
        }

        #endregion
    }
}
