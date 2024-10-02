using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Woodson.Chapter24.Models;

namespace Woodson.Chapter24.Pages.Customers;
[BindProperties]

public class AddCustomerModel : PageModel
{
    public string Message;
    public string MessageColor;

    private readonly SportsPlayContext SportsPlayContext;
    public AddCustomerModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public Customer Customer { get; set; }
    public void OnGet()
    {
        MessageColor = "Green";
        Message = "Please fill in the information below and click Add.";
    }

    public async Task<IActionResult> OnPostAddAsync()
    {
        try
        {
            SportsPlayContext.Customer.Add(Customer);
            await SportsPlayContext.SaveChangesAsync();
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = " was successfully added.";
        }
        catch (DbUpdateException objDbUpdateException)
        {
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = " was NOT added." + objDbUpdateException.InnerException.Message;
        }
        return Redirect("MaintainCustomers");
    }
}
