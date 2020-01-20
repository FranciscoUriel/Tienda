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
    [Route("api/Carrito")]
    public class CarritoController : ControllerBase
    {
        private readonly TiendaContext _context;
        public CarritoController(TiendaContext context)
        {
            _context = context;
        }
        public Prod_Car prodCar = new Prod_Car();



        [HttpPost]
        [Route("{idpro}/{idCar}")]
        public async Task<IActionResult> Post(int idpro, int idCar)
        {
            var producto = await _context.Producto.FindAsync(idpro);
            var carrito = await _context.Carritos.FindAsync(idCar);
            if(producto == null || carrito == null)
            {
                return NotFound();
            }
            prodCar.Carrito = carrito;
            prodCar.Producto = producto;
            _context.ProdCar.Add(prodCar);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prodCar = await _context.ProdCar.FindAsync(id);
            if(prodCar == null)
            {
                return NotFound();
            }
             _context.Remove(prodCar);

            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}
