using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tienda.Persistence.DBContext;

namespace Tienda.Controllers
{
    [Produces("application/json")]
    [Route("api/Categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly TiendaContext _context;

        public CategoriaController(TiendaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// DELETE: /api/Categoria/test-1234
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categroria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categroria.Remove(categoria);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}