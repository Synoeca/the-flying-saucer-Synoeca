using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
	/// <summary>
	/// A public property to get and set IEnumerables of menu items
	/// </summary>
	public class IndexModel : PageModel
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
		/// A private backing field for the property CaloriesMin
		/// </summary>
		private decimal _caloriesMin = 0;

		/// <summary>
		/// A property to store the minimum calories from the user
		/// </summary>
		public decimal CaloriesMin
		{
			get
			{
				if (_caloriesMin == 0)
				{
					decimal min = decimal.MaxValue;
					foreach (IMenuItem menu in Menus)
					{
						if (menu.Calories < min) { min = menu.Calories; }
					}
					_caloriesMin = min;
				}
				return _caloriesMin;
			}
			set => _caloriesMin = value;
		}

		/// <summary>
		/// A private backing field for the property CaloriesMax
		/// </summary>
		private decimal _caloriesMax = -1;

		/// <summary>
		/// A property to store the maximum calories from the user
		/// </summary>
		public decimal CaloriesMax
		{
			get
			{
				if (_caloriesMax == -1)
				{
					decimal max = decimal.MinValue;
					foreach (IMenuItem menu in Menus)
					{
						if (menu.Calories > max) { max = menu.Calories; }
					}
					_caloriesMax = max;
				}
				return _caloriesMax;
			}
			set => _caloriesMax = value;
		}

		/// <summary>
		/// A private backing field for the property PriceMin
		/// </summary>
		private decimal _priceMin = 0;

		/// <summary>
		/// A property to store the minimum price from the user
		/// </summary>
		public decimal PriceMin
		{
			get
			{
				if (_priceMin == 0)
				{
					decimal min = decimal.MaxValue;
					foreach (IMenuItem menu in Menus)
					{
						if (menu.Price < min) { min = menu.Price; }
					}
					_priceMin = min;
				}
				return _priceMin;
			}
			set => _priceMin = value;
		}

		/// <summary>
		/// A private backing field for the property PriceMax
		/// </summary>
		private decimal _priceMax = -1;

		/// <summary>
		/// A property to store the maximum price from the user
		/// </summary>
		public decimal PriceMax
		{
			get
			{
				if (_priceMax == -1)
				{
					decimal max = decimal.MinValue;
					foreach (IMenuItem menu in Menus)
					{
						if (menu.Price > max) { max = menu.Price; }
					}
					_priceMax = max;
				}
				return _priceMax;
			}
			set => _priceMax = value;
		}


		/// <summary>
		/// A method to handle the get request
		/// </summary>
		public void OnGet()
		{
			SearchTerms = Request.Query["SearchTerms"]!;
			Types = Request.Query["Types"]!;
			if (double.TryParse(Request.Query["CaloriesMin"], out double resultCalMin) && double.TryParse(Request.Query["CaloriesMax"], out double resultCalMax))
			{
				CaloriesMin = Decimal.Parse(Request.Query["CaloriesMin"]!);
				CaloriesMax = Decimal.Parse(Request.Query["CaloriesMax"]!);
			}
			if (double.TryParse(Request.Query["PriceMin"], out double resultPriceMin) && double.TryParse(Request.Query["PriceMax"], out double resultPriceMax))
			{
				PriceMin = Decimal.Parse(Request.Query["PriceMin"]!);
				PriceMax = Decimal.Parse(Request.Query["PriceMax"]!);
			}
			Menus = Menu.Search(SearchTerms!);
			Menus = Menu.FilterByItemTypes(Menus, Types);
			Menus = Menu.FilterByCalories(Menus, CaloriesMin, CaloriesMax);
			Menus = Menu.FilterByPrice(Menus, PriceMin, PriceMax);
		}
	}
}