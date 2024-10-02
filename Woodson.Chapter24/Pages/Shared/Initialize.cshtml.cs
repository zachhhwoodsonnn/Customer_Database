using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Woodson.Chapter24.Pages.Shared;

public class InitializeModel : PageModel
{
    public RedirectResult OnGet()
    {
        TempData["strMessageColor"] = "Green";
        TempData["strMessage"] = "Please choose an option below";
        return Redirect("/Customers/MaintainCustomers");
    }
}
