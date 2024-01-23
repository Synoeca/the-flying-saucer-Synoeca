using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheFTL.Website.Pages
{
	/// <summary>
	/// A public property to get and set IEnumerables of cart items
	/// </summary>
	public class CartModel : PageModel
    {
        /// <summary>
        /// Order Class for the cart
        /// </summary>
        public Order Cart { get; set; } = new();

		public void OnGet()
        {
        }
    }
}
