using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Persistence.Entities
{
    public class Carrito
    {
        [Key]
        public int IdCar { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public ICollection<Sale> sale { get; set; }

         public bool Vendido { get; set; }
        public Usuarios Usuario { get; set; }


        public ICollection<Prod_Car> ProdCar { get; set; }
    }
}
