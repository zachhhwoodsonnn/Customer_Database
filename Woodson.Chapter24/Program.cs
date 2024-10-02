using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Woodson.Chapter24.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SportsPlayContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SportsPlayConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

//public partial class Customer
//{
//    [Display(Name = "CustomerID")]
//    public int? CustomerID { get; set; }

//    [Display(Name = "Last Name")]
//    public string? LastName { get; set; }

//    [Display(Name = "First Name")]
//    public string? FirstName { get; set; }

//    [Display(Name = "Middle Initial")]
//    public string? MiddleInitial { get; set; }

//    [Display(Name = "Address")]
//    public string? Address { get; set; }

//    [Display(Name = "City")]
//    public string? City { get; set; }

//    [Display(Name = "State")]
//    public string? State { get; set; }

//    [Display(Name = "Zip Code")]
//    public string? ZipCode { get; set; }

//    [Display(Name = "Phone")]
//    public string? Phone { get; set; }

//    [Display(Name = "Email Address")]
//    public string? EmailAddress { get; set; }

//    [Display(Name = "Password")]
//    public string? Password { get; set; }

//    [Display(Name = "Notes")]
//    public string? Notes { get; set; }
//}
