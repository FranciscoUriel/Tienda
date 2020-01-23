using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Persistence.DBContext;

namespace Tienda.Controllers
{
    [Produces("application/json")]
    [Route("api/CarritoCantidad")]
    public class CarritoCantidadControllers : ControllerBase
    {
        private readonly TiendaContext _context;
        public CarritoCantidadControllers(TiendaContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("{idPC}/{can}/{idPro}")]
        public async Task<IActionResult> Post(int idPC, int can,int idPro)
        {
            var prodCar = await _context.ProdCar.FindAsync(idPC);
            var producto = await _context.Producto.FindAsync(idPro);
            if (prodCar == null)
            {
                return NotFound();
            }
            if (prodCar.Cantidad <= 1 && can < 0 || producto.Cantidad <=0 && can > 0)
            {
                return NotFound();
            }
            producto.Cantidad -= can;
            prodCar.Cantidad += can;
            _context.ProdCar.Update(prodCar);
            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
