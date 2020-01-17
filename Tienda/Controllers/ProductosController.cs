using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tienda.Persistence.DBContext;

namespace Tienda.Controllers
{
    [Produces("application/json")]
    [Route("api/Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly TiendaContext _contexto;
        public ProductosController(TiendaContext context)
        {
            _contexto = context;
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _contexto.Producto.FindAsync(id);
            if(producto == null)
            {
                return NoContent();
            }
            _contexto.Remove(producto);

            await _contexto.SaveChangesAsync();
            
            return Ok();
        }


    }
}
