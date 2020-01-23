using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private IList<Prod_Car> existente { get; set; }
        private IList<Carrito> car { get; set; }
        private IList<Producto> pro { get; set; }

        /// <summary>
        /// Agrega la cantidad de producto solicitado
        /// </summary>
        /// <param name="idpro"></param>
        /// <param name="idCar"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idpro}/{idCar}/{cantidad}")]
        public async Task<IActionResult> Post(int idpro, int idCar,int cantidad)
        {

            existente = await _context.ProdCar.ToListAsync();
            var producto = await _context.Producto.FindAsync(idpro);
            var carrito = await _context.Carritos.FindAsync(idCar);
            car = await _context.Carritos.ToListAsync();
            pro = await _context.Producto.ToListAsync();
            if(producto == null || carrito == null)
            {
                return NotFound();
            }
            producto.Cantidad -= cantidad;

            if(producto.Cantidad < 0)
            {
                return NotFound();
            }

            prodCar.Carrito = carrito;
            prodCar.Producto = producto;
            prodCar.Cantidad = cantidad;
            foreach (var item in existente)
            {
                if(item.Carrito.IdCar == idCar && item.Producto.IdProducto == idpro)
                {

                    item.Cantidad += cantidad;

                    _context.ProdCar.Update(item);
                    _context.Producto.Update(producto);
                    _context.SaveChanges();
                    return Ok();
                }
            }

            _context.ProdCar.Add(prodCar);
            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Encarfado de borrar por compreto algun producto del carrito
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/{idPro}")]
        public async Task<IActionResult> Delete(int id, int idPro)
        {
            var prodCar = await _context.ProdCar.FindAsync(id);
            var producto = await _context.Producto.FindAsync(idPro);
            pro = await _context.Producto.ToListAsync();
            if (prodCar == null)
            {
                return NotFound();
            }
            producto.Cantidad += prodCar.Cantidad;
             _context.Remove(prodCar);
            _context.Producto.Update(producto);

            await _context.SaveChangesAsync();
            
            return Ok();
        }
      
    }
}
