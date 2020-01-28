using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly TiendaContext _context;
        
        public IndexModel(TiendaContext context)
        {
            _context = context;
        }
        public IList<Sale> sales { get; set; }
        private IList<Usuarios> user { get; set; }
        private IList<Carrito> car { get; set; }
        public async Task OnGetAsync()
        {
            sales = await _context.Sale.ToListAsync();
            user = await _context.Users.ToListAsync();
            car = await _context.Carritos.ToListAsync();
        }
    }
}
