using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace crud.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _db.Customers.FindAsync(id);
            if (Customer == null)
                RedirectToPage("/Index");
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();
            _db.Attach(Customer).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new 
                    Exception($"No se pudo ingresar el cliente {Customer.Name}"); 
            }
            return RedirectToPage("/Index");

        }
        public EditModel(AppDbContext db)
        {
            _db = db;

        }
    }
}