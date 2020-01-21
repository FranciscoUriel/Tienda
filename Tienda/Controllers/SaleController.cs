using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda.Controllers
{
    [Produces("application/json")]
    [Route("api/Sale")]
    public class SaleController : ControllerBase
    {
        private readonly TiendaContext _context;
        public SaleController(TiendaContext context)
        {
            _context = context;
        }
        public Sale sale = new Sale();
        public Carrito newcar = new Carrito();

        [HttpPost]
        [Route("{idcar}/{total}")]
        public async Task<IActionResult> Post(int idcar, decimal total)
        {
            var oldCar = await _context.Carritos.FindAsync(idcar);
            if (oldCar == null)
            {
                return NotFound();

            }
            sale.carrito = oldCar;
            sale.Total = total;
            sale.Fecha = DateTime.Now;           
            newcar.Fecha = DateTime.Now;

            await _context.Sale.AddAsync(sale);
            await _context.Carritos.AddAsync(newcar);

            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
