using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda
{
    [Authorize(Roles = "Administrador")]
    public class DetailsCatModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;

        public DetailsCatModel(Tienda.Persistence.DBContext.TiendaContext context)
        {
            _context = context;
        }

        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categroria.FirstOrDefaultAsync(m => m.NomCategoria == id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
