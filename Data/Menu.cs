using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFTL.Data
{
    /// <summary>
    /// A static class contains IEnumerable of menu items for website
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Gets the possible Item types
        /// </summary>
        public static string[] ItemTypes
        {
            get => new string[]
            {
                "Entree",
                "Side",
                "Drink"
            };
        }

        /// <summary>
        /// Returns IEnumerable of IMenuitem containing an instance of
        /// all avbailable entrees in their default configuration
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees
        {
            get
            {
                List<IMenuItem> entrees = new()
                {
                    new CrashedSaucer(),
                    new FlyingSaucer(),
                    new LivestockMutilation(),
                    new OuterOmelette()
                };
                return entrees;
            }
        }

        /// <summary>
        /// Returns IEnumerable of IMenuitem containing an instance of all avbailable sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<IMenuItem> sides = new()
                {
                    new CropCircle(),
                    new MissingLinks(),
                    new GlowingHaystack(),
					new EvisceratedEggs(),
					new TakenBacon(),
                    new YouAreToast()
                };
                return sides;
            }
        }

        /// <summary>
        /// Returns IEnumerable of IMenuitem containing an instance of all avbailable drinks
        /// As each drink has 3 different sizes, this collection
        /// should contain a small and large instance of each.
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<IMenuItem> drinks = new()
                {
                    /*
                    new InorganicSubstance() { Size=ServingSize.Small },
                    new InorganicSubstance() { Size=ServingSize.Medium },
                    new InorganicSubstance() { Size=ServingSize.Large },
                    new LiquifiedVegetation() { Size=ServingSize.Small },
                    new LiquifiedVegetation() { Size=ServingSize.Medium },
                    new LiquifiedVegetation() { Size=ServingSize.Large },
                    new SaucerFuel() { Size=ServingSize.Small },
                    new SaucerFuel() { Size=ServingSize.Medium },
                    new SaucerFuel() { Size=ServingSize.Large }
                    */
                    new InorganicSubstance(),
					new LiquifiedVegetation(),
					new SaucerFuel()
				};
                return drinks;
            }
        }

        /// <summary>
        /// Returns IEnumerable of IMenuitem containing all of the items on the menu
        /// (one of each of the items found in the categories above)
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> fullmenu = new();
                foreach (IMenuItem imi in Entrees)
                {
                    fullmenu.Add(imi);
                }
                foreach (IMenuItem imi in Sides)
                {
                    fullmenu.Add(imi);
                }
                foreach (IMenuItem imi in Drinks)
                {
                    fullmenu.Add(imi);
                }
                return fullmenu;
            }
        }

        /// <summary>
        /// Filters the provided collection of items
        /// </summary>
        /// <param name="items">The collection of items to filter</param>
        /// <param name="types">The types to include</param>
        /// <returns>the items filtered by types</returns>
        public static IEnumerable<IMenuItem> FilterByItemTypes(IEnumerable<IMenuItem> items, IEnumerable<string> types)
        {
            if (types == null || types.Count() == 0) { return items; }

            List<IMenuItem> results = new();
            foreach (IMenuItem item in items)
            {
                string itemType = "";
                if (item is Entree)
                {
                    itemType = "Entree";
                }

                if (item is Side)
                {
                    itemType = "Side";
                }

                if (item is Drink)
                {
                    itemType = "Drink";
                }

                if (types.Contains(itemType))
                {
                    results.Add(item);
                }

            }
            return results;
        }

        /// <summary>
        /// Filters the provided collection of movies
        /// to those with IMDB ratings falling within
        /// the specified range
        /// </summary>
        /// <param name="menus">The collection of movies to filter</param>
        /// <param name="min">The minimum range value</param>
        /// <param name="max">The maximum range value</param>
        /// <returns>The filtered movie collection</returns>
        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> menus, decimal? min, decimal? max)
        {
            if (min == null && max == null) return menus;
            List<IMenuItem> results = new();

            // only a maximum specified
            if (min == null)
            {
                foreach (IMenuItem menu in menus)
                {
                    if (menu.Calories <= max) results.Add(menu);
                }
                return results;
            }

            if (max == null)
            {
                foreach (IMenuItem menu in menus)
                {
                    if (menu.Calories >= min) results.Add(menu);
                }
                return results;
            }

            foreach (IMenuItem menu in menus)
            {
                if (menu.Calories >= min && menu.Calories <= max)
                {
                    results.Add(menu);
                }
            }
            return results;
        }

        /// <summary>
        /// Filters the provided collection of movies
        /// to those with IMDB ratings falling within
        /// the specified range
        /// </summary>
        /// <param name="menus">The collection of movies to filter</param>
        /// <param name="min">The minimum range value</param>
        /// <param name="max">The maximum range value</param>
        /// <returns>The filtered movie collection</returns>
        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> menus, decimal? min, decimal? max)
        {
            if (min == null && max == null) return menus;
            List<IMenuItem> results = new();

            // only a maximum specified
            if (min == null)
            {
                foreach (IMenuItem menu in menus)
                {
                    if (menu.Price <= max) results.Add(menu);
                }
                return results;
            }

            if (max == null)
            {
                foreach (IMenuItem menu in menus)
                {
                    if (menu.Price >= min) results.Add(menu);
                }
                return results;
            }

            foreach (IMenuItem menu in menus)
            {
                if (menu.Price >= min && menu.Price <= max)
                {
                    results.Add(menu);
                }
            }
            return results;
        }

        /// <summary>
        /// Summary the movies in the database for matches
        /// </summary>
        /// <param name="terms">The terms to search for</param>
        /// <returns>The results of the search</returns>
        public static IEnumerable<IMenuItem> Search(string terms)
        {
            List<IMenuItem> results = new();
            // null check
            if (terms == null) { return FullMenu; }

            string[] searchTerms = terms.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (IMenuItem menu in FullMenu)
            {
                bool allTermsMatch = true;
                foreach (string term in searchTerms)
                {
                    if (menu.Name == null || !menu.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase))
                    {
                        allTermsMatch = false;
                        break;
                    }
                }

                if (allTermsMatch) { results.Add(menu); }
            }

            return results;
        }
    }
}
