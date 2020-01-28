using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        private readonly TiendaContext _tiendaContext;
        private readonly UserManager<Usuarios> _userManager;

        public IndexModel(TiendaContext tiendaContext, UserManager<Usuarios> userManager)
        {
            _tiendaContext = tiendaContext;
            _userManager = userManager;
        }
        public IList<Usuarios> user { get; set; }
        [BindProperty]
        public Usuarios prueba { get; set; }
        private IList<IdentityRole> roles { get; set; }        
        private IList<IdentityUserRole<string>> userRole { get; set; }



        public async Task OnGetAsync()
        {
            user = await _tiendaContext.Users.ToListAsync();
            roles = await _tiendaContext.Roles.ToListAsync();
            userRole = await _tiendaContext.UserRoles.ToListAsync();
        }
       /* public async Task<IActionResult> OnPostAsync(string item_Id)
        {
            var use = await _userManager.FindByIdAsync(item_Id);
            user = await _tiendaContext.Users.ToListAsync();
            roles = await _tiendaContext.Roles.ToListAsync();
            userRole = await _tiendaContext.UserRoles.ToListAsync();
            if (RoleDelUsuario(item_Id) != "Administrador")
            {
                await _userManager.RemoveFromRoleAsync(use, "Cliente");
                await _userManager.AddToRoleAsync(use, "Administrador");
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(use, "Administrador");
                await _userManager.AddToRoleAsync(use, "Cliente");
            }
            return RedirectToPage("./Index");
        }
        */

        //public async Task RoleChange(int chance, Usuarios use)
        //{
        //    if (chance == 0)
        //    {
        //        await _userManager.RemoveFromRoleAsync(use, "Cliente");
        //        await _userManager.AddToRoleAsync(use, "Administrador");
        //    }
        //    else
        //    {
        //        await _userManager.RemoveFromRoleAsync(use, "Administrador");
        //        await _userManager.AddToRoleAsync(use, "Cliente");
        //    }
        //}


        public string RoleDelUsuario(string idUser)
        {
            
            foreach (var item in userRole)
            {
                if(item.UserId == idUser)
                {
                    foreach (var item2 in roles)
                    {
                        if (item2.Id == item.RoleId )
                        {
                            return item2.Name;
                        }
                    }
                }
            }
            return null;
        }
    }
}
