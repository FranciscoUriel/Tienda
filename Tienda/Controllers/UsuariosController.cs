using Microsoft.AspNetCore.Identity;
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
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly TiendaContext _contexto;
        private readonly UserManager<Usuarios> _userManager;
        public UsuariosController(TiendaContext context, UserManager<Usuarios> userManager)
        {
            _contexto = context;
            _userManager = userManager;
        }
        private Usuarios user = new Usuarios();
        [HttpPost]
        [Route("{admi}/{idUsuario}")]
        public async Task<IActionResult> OnPostAsync(int admi,string idUsuario)
        {
            user = await _userManager.FindByIdAsync(idUsuario);
            if (admi == 0)
            {
                await _userManager.RemoveFromRoleAsync(user, "Cliente");
                await _userManager.AddToRoleAsync(user, "Administrador");
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, "Administrador");
                await _userManager.AddToRoleAsync(user, "Cliente");
            }
            return Ok();
        }
    }
}
