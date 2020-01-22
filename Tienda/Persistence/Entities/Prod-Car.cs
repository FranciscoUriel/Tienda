using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Persistence.Entities
{
    public class Prod_Car
    {
        [Key]
        public int IdProdCar { get; set; }
        public Producto Producto { get; set; }
        [Display(Name ="Cantidad")]
        public int Cantidad { get; set; }
        
        public Carrito Carrito { get; set; }
       
    }
}
