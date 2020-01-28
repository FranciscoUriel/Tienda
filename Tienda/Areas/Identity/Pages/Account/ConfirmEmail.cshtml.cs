using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly TiendaContext _context;
        public ConfirmEmailModel (TiendaContext context)
        {
            _context = context;
        }
        public Usuarios user = new Usuarios();
        public async Task<IActionResult> OnGetAsync(string handler)
        {
            user = await _context.Users.FindAsync(handler);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var modif = user;
            modif.EmailConfirmed = true;
            
            _context.Users.Update(modif);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
