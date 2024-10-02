using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Woodson.Chapter24.Models;

namespace Woodson.Chapter24.Pages.Customers;

public class MaintainCustomersModel : PageModel
{
    public string Message;
    public string MessageColor;

    private readonly SportsPlayContext SportsPlayContext;
    public MaintainCustomersModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public string? LastName;
        public string? FirstName;
        public string? MiddleInitial;
        public string? Address;
        public string? City;
        public string? State;
        public string? ZipCode;
        public string? Phone;
        public string? EmailAddress;
        public string? Password;
        public string? Notes;
        public int? CustomerID;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {
        if (TempData["strMessageColor"] == null)
        {
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = "Please choose an option below";
        }
        else
        {
            MessageColor = TempData["strMessageColor"].ToString();
            Message = TempData["strMessage"].ToString();
        }

        ResultIQueryable = (
            from c in SportsPlayContext.Customer
            orderby c.LastName, c.FirstName, c.MiddleInitial
            select new Result
            {
                LastName = c.LastName,
                FirstName = c.FirstName,
                MiddleInitial = c.MiddleInitial,
                Address = c.Address,
                City = c.City,
                State = c.State,
                ZipCode = c.ZipCode,
                Phone = c.Phone,
                EmailAddress = c.EmailAddress,
                Password = c.Password,
                Notes = c.Notes,
                CustomerID = c.CustomerID
            });

        ResultIList = await ResultIQueryable.ToListAsync();
    }
}
