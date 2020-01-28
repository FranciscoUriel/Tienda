using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Persistence.Entities
{

    public class Usuarios : IdentityUser
    {
       
        public string FirsName { get; set; }
     
        public string LastName { get; set; }

        public ICollection<Carrito> Carrito { get; set; }
    }
}
