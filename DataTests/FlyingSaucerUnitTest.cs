using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the FlyingSaucer class
    /// </summary>
    public class FlyingSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Flying Saucer has 6 panacakes
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeSixPancakes()
        {
            FlyingSaucer fs = new();
            Assert.Equal(6u, fs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered Flying Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with berries
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Berries);
        }

        /// <summary>
        /// Checks that an unmodified Flying Saucer is served with whipped cream
        /// </summary>
        [Fact]
        public void DefaultServedWithWhippedCream()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.WhippedCream);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void NameShouldAlwaysBeFlyingSaucer(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("Flying Saucer", fs.Name);
            Assert.Equal("A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.", fs.Description);
        }

        /// <summary>
        /// This test verifies that a FlyingSaucer's StackSize cannot exceed 12, and 
        /// if it is attempted, the StackSize will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveTwelve()
        {
            FlyingSaucer fs = new();
            fs.StackSize = 13;
            Assert.Equal(12u, fs.StackSize);
        }

        /// <summary>
        /// This test verifies that a FlyingSaucer's Price defaults to $8.50,
        /// plus and additional $0.75 for each additional slice beyond the default
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="price">The total price expected</param>
        /// <param name="decreased">The price of FlyingSaucer instance when one stack size decreased</param>
        /// <param name="increased">The price of FlyingSaucer instance when two stack size increased</param>
        [Theory]
        [InlineData(7, 9.25, 8.50, 10.00)]
        [InlineData(8, 10.00, 9.25, 10.75)]
        [InlineData(9, 10.75, 10.00, 11.50)]
        [InlineData(10, 11.50, 10.75, 12.25)]
        [InlineData(11, 12.25, 11.50, 13.00)]
        [InlineData(12, 13.00, 12.25, 13.00)]
        [InlineData(13, 13.00, 12.25, 13.00)]
        [InlineData(14, 13.00, 12.25, 13.00)]
        public void PriceShouldBeCorrect(uint stackSize, decimal price, decimal decreased, decimal increased)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize
            };
            Assert.Equal(price, fs.Price);
            fs.StackSize--;
            Assert.Equal(decreased, fs.Price);
            fs.StackSize += 2;
            Assert.Equal(increased, fs.Price);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(6u, true, true, true, 64u * 6u + 32u + 414u + 89u)]
        [InlineData(0u, true, true, true, 64u * 0u + 32u + 414u + 89u)]
        [InlineData(12u, true, true, true, 64u * 12u + 32u + 414u + 89u)]
        [InlineData(6u, true, false, true, 64u * 6u + 32u + 0u + 89u)]
        [InlineData(6u, false, false, true, 64u * 6u + 0u + 0u + 89u)]
        [InlineData(3u, true, false, false, 64u * 3u + 32u + 0u + 0u)]
        [InlineData(8u, false, false, false, 64u * 8u + 0u + 0u + 0u)]
        [InlineData(11u, true, true, false, 64u * 11u + 32u + 414u + 0u)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool whippedCream, bool berries, uint calories)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal(calories, fs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="stackSize">The number of panacakes</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="whippedCream">If served with whipped cream</param>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(4, true, true, true, new string[] { "4 Pancakes" })]
        [InlineData(5, false, false, false, new string[] { "5 Pancakes", "Hold Syrup", "Hold Whipped Cream", "Hold Berries" })]
        [InlineData(6, true, true, true, new string[] {})]
        [InlineData(6, false, false, false, new string[] { "Hold Syrup", "Hold Whipped Cream", "Hold Berries" })]
        [InlineData(8, true, false, true, new string[] { "8 Pancakes", "Hold Whipped Cream" })]
        [InlineData(11, true, true, false, new string[] { "11 Pancakes" , "Hold Berries" })]
        [InlineData(12, false, true, false, new string[] { "12 Pancakes" , "Hold Syrup" , "Hold Berries" })]
        [InlineData(13, false, true, true, new string[] { "12 Pancakes", "Hold Syrup" })]

        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool whippedCream, bool berries, string[] instructions)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach(string instruction in instructions)
            {
                Assert.Contains(instruction, fs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, fs.SpecialInstructions.Count());
        }

        /// <summary>
        /// Checks that the menu items in this class can be cast to an Entree and an IMenuItem
        /// </summary>
        [Fact]
        public void CouldBeCast()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<Entree>(fs);
            Assert.IsAssignableFrom<IMenuItem>(fs);
        }

        /// <summary>
        /// Checks that overrided ToString method provides class Name proprety instead
        /// </summary>
        [Fact]
        public void ToStringShouldProvideCorrectName()
        {
            FlyingSaucer fs = new();
            Assert.Equal(fs.Name, fs.ToString());
        }

        /// <summary>
        /// Checks that menu item classes implements the INotifyPropertChanged interface
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(fs);
        }

        #endregion
    }
}