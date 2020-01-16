using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Persistence.Entities
{
    public class Sale
    {

        [Key]
        public int IdSale { get; set; }
        [Required]
        public DateTime Fecha { get; set; }


        public ICollection<Carrito> Carrito { get; set; }
    }
}
