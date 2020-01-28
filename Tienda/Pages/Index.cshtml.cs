using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.Entities;

namespace Tienda
{
    public class IndexModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuarios> _userManager;


        public IndexModel(Tienda.Persistence.DBContext.TiendaContext context,RoleManager<IdentityRole> roleManager, UserManager<Usuarios> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IList<Producto> productos { get; set; }
        public IList<Categoria> categorias { get; set; }
        private IList<Usuarios> user { get; set; }
        public IList<Carrito> Car { get; set; }
        public async Task OnGetAsync()
        {
            user = await _context.Users.ToListAsync();
            productos = await _context.Producto.ToListAsync();
            categorias = await _context.Categroria.ToListAsync();
            Car = await _context.Carritos.ToListAsync();
            
        }
        //public async Task OnPostAsync() 
        //{
        //    var user = await _userManager.FindByIdAsync("cc5a7ea2-249e-4eb4-afd2-9711aec625b6");
        //    await _userManager.AddToRoleAsync(user, "Administrador");
            
        //}
        public int idCarrito(string nameUser)
        {
            foreach (var item in Car)
            {
                if(item.Usuario.UserName == nameUser && item.Vendido == false)
                {
                    return item.IdCar;
                }
            }
            return 0;
        }
    }
}