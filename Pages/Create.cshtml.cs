using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        private ILogger<CreateModel> Log;

        public CreateModel(AppDbContext db, ILogger<CreateModel> log)
        {
            _db = db;
            Log = log;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        [TempData]
        public string Message { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} added!";
            return RedirectToPage("/Index");
        }
    }
}