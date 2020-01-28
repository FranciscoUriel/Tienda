using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.Entities;

namespace Tienda.Pages.Productos
{
    [Authorize(Roles = "Administrador")]
    public class DetallesModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;

        public DetallesModel(Tienda.Persistence.DBContext.TiendaContext context)
        {
            _context = context;
        }
        public Producto productos { get; set; }
        public IList<Categoria> categoria { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            productos = await _context.Producto.FirstOrDefaultAsync(m => m.IdProducto == id);
            categoria = await _context.Categroria.ToListAsync();
            
            if (productos == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}
