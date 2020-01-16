using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda
{
    public class CreateCatModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;

        public CreateCatModel(Tienda.Persistence.DBContext.TiendaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categroria.Add(Categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexCategoria");
        }
    }
}
