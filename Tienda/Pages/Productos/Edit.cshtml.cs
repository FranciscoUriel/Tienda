using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.Entities;

namespace Tienda.Pages.Productos
{
    public class EditModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;
        public EditModel(Tienda.Persistence.DBContext.TiendaContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Producto productos { get; set; }
        public IList<Categoria> categoria { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            _context.Attach(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductoExist(productos.IdProducto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }
        private async Task<bool> ProductoExist(int? id)
        {
            return await _context.Producto.AnyAsync(m => m.IdProducto == id);
        }
        private async Task<bool> CategoriaExiste(string nombre)
        {
            return await _context.Categroria.AnyAsync(m => m.NomCategoria == nombre);
        }
    }
}
