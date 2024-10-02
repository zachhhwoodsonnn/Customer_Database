using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Woodson.Chapter24.Models;

namespace Woodson.Chapter24.Pages.Customers;
[BindProperties]
public class ModifyCustomerModel : PageModel
{
    public string MessageColor;
    public string Message;

    private readonly SportsPlayContext SportsPlayContext;
    public ModifyCustomerModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public Customer Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int intCustomerID)
    {
        MessageColor = "Green";
        Message = "Please modify the information below and click Modify.";

        Customer = await
            SportsPlayContext.Customer.FindAsync(intCustomerID);
        if (Customer != null)
        {
            return Page();
        }
        else
        {
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = "The selected customer was deleted by someone else.";
            return Redirect("MaintainCustomers");
        }
    }

    public async Task<IActionResult> OnPostModifyAsync()
    {
        try
        {
            SportsPlayContext.Customer.Update(Customer);
            await SportsPlayContext.SaveChangesAsync();
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = "Customer was modified.";
        }
        catch (DbUpdateException objDbUpdateException)
        {
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = "Customer was not modified. Please report this to the admin" + objDbUpdateException.InnerException.Message;
        }
        return Redirect("MaintainCustomers");
    }
}
