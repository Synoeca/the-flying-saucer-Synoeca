using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Linq;

namespace TheIndex.DataTests
{
    /// <summary>
    /// Unit tests for the Index.cshtml.cs class
    /// </summary>
    public class IndexUnitTest
    {
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockIndexModel : PageModel
        {
            /// <summary>
            /// A public property to get and set IEnumerables of menus
            /// </summary>
            public IEnumerable<IMenuItem> Menus { get; set; } = default!;

            /// <summary>
            /// A property to store the search terms from the user
            /// </summary>
            public string SearchTerms { get; set; } = default!;

            /// <summary>
            /// A filtered menu types
            /// </summary>
            public string[] Types { get; set; } = default!;

            /// <summary>
            /// A property to store the minimum calories from the user
            /// </summary>
            public decimal CaloriesMin { get; set; }

            /// <summary>
            /// A property to store the maximum calories from the user
            /// </summary>
            public decimal CaloriesMax { get; set; }

            /// <summary>
            /// A property to store the minimum price from the user
            /// </summary>
            public decimal PriceMin { get; set; }

            /// <summary>
            /// A property to store the maximum price from the user
            /// </summary>
            public decimal PriceMax { get; set; }
            
        }

        /// <summary>
        /// This test checks that the properties in the Index.cshtml.cs has the default value
        /// </summary>
        [Fact]
        public void IndexModelShouldBeDefault()
        {
            MockIndexModel mim = new();
            Assert.Null(mim.Menus);
            Assert.Null(mim.SearchTerms);
            Assert.Null(mim.Types);
            Assert.Equal(0, mim.CaloriesMin);
            Assert.Equal(0, mim.CaloriesMax);
            Assert.Equal(0, mim.PriceMin);
            Assert.Equal(0, mim.PriceMax);
        }

        /// <summary>
        /// This test checks that the properties in the the default search without any user input
        /// should get full menus
        /// </summary>
        [Fact]
        public void DefaultSearchShouldBeDisplayAll()
        {
            MockIndexModel mim = new();
            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );
        }

        /// <summary>
        /// This test check that the search result should reflect filtered searchterms
        /// </summary>
        [Fact]
        public void SearchTermsShouldBeFiltered()
        {
            MockIndexModel mim = new();
            mim.SearchTerms = "Saucer";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );
            mim.SearchTerms = "Saucer Crashed";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item)
            );
        }

        /// <summary>
        /// This test check that the search result should reflect filtered searchterms
        /// </summary>
        [Fact]
        public void TypesShouldBeFiltered()
        {
            MockIndexModel mim = new();
            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            List<string> typeEntree = new() { "Entree" };
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeEntree);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            List<string> typeSide = new() { "Side" };
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeSide);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            List<string> typeDrink = new() { "Drink" };
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeDrink);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            List<string> typeEntreeSide = new() { "Entree", "Side" };
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeEntreeSide);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            List<string> typeEntreeDrink = new() { "Entree" , "Drink" };
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeEntreeDrink);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            List<string> typeSideDrink = new() { "Side", "Drink" };
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeSideDrink);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            List<string> typeEntreeSideDrink = new() { "Entree", "Side", "Drink" };
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeEntreeSideDrink);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );
        }

        /// <summary>
        /// This test check that the search result should reflect filtered calories
        /// </summary>
        [Fact]
        public void CaloriesShouldBeFiltered()
        {
            MockIndexModel mim = new();
            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.CaloriesMin = 0;
            mim.CaloriesMax = 919;
            mim.Menus = Menu.FilterByCalories(mim.Menus, mim.CaloriesMin, mim.CaloriesMax);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.CaloriesMin = 100;
            mim.CaloriesMax = 800;
            mim.Menus = Menu.FilterByCalories(mim.Menus, mim.CaloriesMin, mim.CaloriesMax);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<YouAreToast>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.CaloriesMin = 200;
            mim.CaloriesMax = 700;
            mim.Menus = Menu.FilterByCalories(mim.Menus, mim.CaloriesMin, mim.CaloriesMax);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<GlowingHaystack>(item),
                item => Assert.IsType<YouAreToast>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.CaloriesMin = 300;
            mim.CaloriesMax = 600;
            mim.Menus = Menu.FilterByCalories(mim.Menus, mim.CaloriesMin, mim.CaloriesMax);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<GlowingHaystack>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.CaloriesMin = 400;
            mim.CaloriesMax = 500;
            mim.Menus = Menu.FilterByCalories(mim.Menus, mim.CaloriesMin, mim.CaloriesMax);
            Assert.Empty(mim.Menus);
        }


        /// <summary>
        /// This test check that the search result should reflect filtered prices
        /// </summary>
        [Fact]
        public void PriceShouldBeFiltered()
        {
            MockIndexModel mim = new();
            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.PriceMin = 0;
            mim.PriceMax = 8.50m;
            mim.Menus = Menu.FilterByPrice(mim.Menus, mim.PriceMin, mim.PriceMax);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<FlyingSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item),
                item => Assert.IsType<InorganicSubstance>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.CaloriesMin = 1;
            mim.CaloriesMax = 2;
            mim.PriceMin = 1;
            mim.PriceMax = 7.50m;
            mim.Menus = Menu.FilterByPrice(mim.Menus, mim.PriceMin, mim.PriceMax);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<LivestockMutilation>(item),
                item => Assert.IsType<OuterOmelette>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item),
                item => Assert.IsType<LiquifiedVegetation>(item),
                item => Assert.IsType<SaucerFuel>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.PriceMin = 2;
            mim.PriceMax = 6.50m;
            mim.Menus = Menu.FilterByPrice(mim.Menus, mim.PriceMin, mim.PriceMax);
            Assert.Collection(mim.Menus,
                item => Assert.IsType<CrashedSaucer>(item),
                item => Assert.IsType<CropCircle>(item),
                item => Assert.IsType<MissingLinks>(item),
                item => Assert.IsType<GlowingHaystack>(item),
				item => Assert.IsType<EvisceratedEggs>(item),
				item => Assert.IsType<TakenBacon>(item),
                item => Assert.IsType<YouAreToast>(item)
            );

            mim.SearchTerms = "";
            mim.Menus = Menu.Search(mim.SearchTerms!);
            mim.PriceMin = 3;
            mim.PriceMax = 5.50m;
            mim.Menus = Menu.FilterByPrice(mim.Menus, mim.PriceMin, mim.PriceMax);
            Assert.Empty(mim.Menus);
        }

        /// <summary>
        /// This test check that multiple filters should return correct search results
        /// </summary>
        [Fact]
        public void MultipleSearchFilterShouldBeApplied()
        {
            MockIndexModel mim = new();
            mim.SearchTerms = "Saucer";
            mim.Menus = Menu.Search(mim.SearchTerms!);

            List<string> typeDrink = new() { "Drink" };
            mim.CaloriesMin = 1;
            mim.CaloriesMax = 2;
            mim.PriceMin = 1.5m;
            mim.PriceMax = 2;
            
            mim.Menus = Menu.FilterByItemTypes(mim.Menus, typeDrink);
            mim.Menus = Menu.FilterByCalories(mim.Menus, mim.CaloriesMin, mim.CaloriesMax);
            mim.Menus = Menu.FilterByPrice(mim.Menus, mim.PriceMin, mim.PriceMax);
            Assert.Empty(mim.Menus);
            /*
            Assert.Collection(mim.Menus,
                item => Assert.IsType<SaucerFuel>(item)
            );

            Assert.Single(mim.Menus);*/
        }
    }
}