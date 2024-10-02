using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Woodson.Chapter24.Pages.Customers;

public class CancelCustomerModel : PageModel
{
    public RedirectResult OnGet()
    {
        TempData["strMessageColor"] = "Red";
        TempData["strMessage"] = "The operation was cancelled. No data was affected.";
        return Redirect("MaintainCustomers");
    }
}
