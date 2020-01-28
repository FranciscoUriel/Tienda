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

namespace Tienda.Pages.Carritos
{
    public class IndexModel : PageModel
    {
        private readonly TiendaContext _context;
       
        public IndexModel(TiendaContext context)
        {
            _context = context;
           
        }
        public IList<Prod_Car> proCar { get; set; }
        public IList<Producto> productos { get; set; }
        public IList<Carrito> Car { get; set; }
        private IList<Usuarios> user { get; set; }
        public async Task OnGetAsync()
        {
            user = await _context.Users.ToListAsync();
            proCar = await _context.ProdCar.ToListAsync();
            productos = await _context.Producto.ToListAsync();
            Car = await _context.Carritos.ToListAsync();
        }
        public Carrito carritoActual()
        {
            foreach (var item in Car)
            {
                if(item.Usuario.UserName == User.Identity.Name && item.Vendido == false)
                {
                   return item;
                    
                }
            }
            return null;
        }


        public decimal Total(int id)
        {
            decimal total = 0;
            foreach (var item in proCar)
            {
                if (item.Carrito.IdCar == id)
                {
                    total = (item.Producto.Precio * item.Cantidad)+total;
                }
            }
            return total;
        }
     
    }
}
