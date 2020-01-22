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
        [Route("{idPC}/{can}")]
        public async Task<IActionResult> Post(int idPC, int can)
        {
            var prodCar = await _context.ProdCar.FindAsync(idPC);
            if (prodCar == null)
            {
                return NotFound();
            }
            prodCar.Cantidad += can;
            _context.ProdCar.Update(prodCar);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
