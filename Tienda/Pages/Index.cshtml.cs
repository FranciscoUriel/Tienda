using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.Entities;

namespace Tienda
{
    public class IndexModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;

        public IndexModel(Tienda.Persistence.DBContext.TiendaContext context)
        {
            _context = context;
        }
        public IList<Producto> productos { get; set; }
        public IList<Categoria> categorias { get; set; }
        public async Task OnGetAsync()
        {
            productos = await _context.Producto.ToListAsync();
            categorias = await _context.Categroria.ToListAsync();
        }
    }
}