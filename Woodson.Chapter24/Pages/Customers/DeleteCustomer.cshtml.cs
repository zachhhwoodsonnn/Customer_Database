using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Woodson.Chapter24.Models;

namespace Woodson.Chapter24.Pages.Customers;

public class DeleteCustomerModel : PageModel
{
    private readonly SportsPlayContext SportsPlayContext;
    public DeleteCustomerModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    private Customer Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int intCustomerID)
    {
        Customer = await
            SportsPlayContext.Customer.FindAsync(intCustomerID);
        if (Customer != null)
        {
            try
            {
                SportsPlayContext.Customer.Remove(Customer);
                await SportsPlayContext.SaveChangesAsync();
                TempData["strMessageColor"] = "Green";
                TempData["strMessage"] = "Customer was successfully deleted.";
            }
            catch (DbUpdateException objDbUpdateException)
            {
                SqlException objSqlException =
                    objDbUpdateException.InnerException as SqlException;
                if (objSqlException.Number == 547)
                {
                    TempData["strMessageColor"] = "Red";
                    TempData["strMessage"] = "Customer was not deleted because they are associted with one or more order lines. You must first deleted the asscoiated order lines.";
                }
                else
                {
                    {
                        TempData["strMessageColor"] = "Red";
                        TempData["strMessage"] = "Customer was not deleted. Please report this to the admin." + objDbUpdateException.InnerException.Message;

                    }
                }
            }
        }
        else
        {
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = "The customer was successfully deleted.";
        }
        return Redirect("MaintainCustomers");
    }
}
