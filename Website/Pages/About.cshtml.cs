using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class AboutModel : PageModel
    {
        /// <summary>
        /// A property to store the search terms from the user
        /// </summary>
        public string SearchTerms { get; set; } = default!;

        public void OnGet()
        {
        }
    }
}
