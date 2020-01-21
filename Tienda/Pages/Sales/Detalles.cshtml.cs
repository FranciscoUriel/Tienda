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
    public class DetallesModel : PageModel
    {
        private readonly TiendaContext _context;
        
        public DetallesModel(TiendaContext context)
        {
            _context = context;
        }

        public Sale sales { get; set; }
        private IList<Carrito> car { get; set; }
        public IList<Prod_Car> prodCar { get; set; }
        private IList<Producto> prod { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            sales = await _context.Sale.FirstOrDefaultAsync(m => m.IdSale == id);
            car = await _context.Carritos.ToListAsync();
            prodCar = await _context.ProdCar.ToListAsync();
            prod = await _context.Producto.ToListAsync();

            if(sales == null)
            {
                return NotFound();
            }
            return Page();
        }
        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in prodCar)
            {
                if (sales.carrito.IdCar == item.Carrito.IdCar)
                {
                    total += item.Producto.Precio;
                }
            }
            return total;
        }

    }
}
