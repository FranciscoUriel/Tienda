using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Models.Productos;
using Tienda.Persistence.Entities;

namespace Tienda.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;
      
        public CreateModel(Tienda.Persistence.DBContext.TiendaContext context)
        {
            _context = context;
           
        }
        [BindProperty]
        public ProductosCreateViewModel productos { get; set; }
        public IList<Categoria> categorias { get; set; }
        public Producto producto = new Producto();
        //public IActionResult OnGet()
        //{

        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync()
        {
            categorias = await _context.Categroria.ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            producto.NomProducto = productos.NomProducto;
            producto.Precio = productos.Precio;
            producto.Detalle = productos.Detalle;
            producto.Cantidad = productos.Cantidad;
            producto.Categoria = await _context.Categroria.FirstOrDefaultAsync(m => m.NomCategoria == productos.Categoria);
            categorias = await _context.Categroria.ToListAsync();
            if (!ModelState.IsValid)
            {
                return Page();
            }
          
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
       


    }
}
