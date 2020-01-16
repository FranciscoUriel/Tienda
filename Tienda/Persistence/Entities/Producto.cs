using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Persistence.Entities
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Display(Name ="Producto")]
        [Required]
        public string NomProducto { get; set; }
        [Display(Name = "Precio")]
        [Required]
        public decimal Precio { get; set; }
        [Display(Name = "Cantidad")]
        [Required]
        public int Cantidad { get; set; }
        [Display(Name = "Detalles")]
        [Required]
        public string Detalle { get; set; }
        [Display(Name = "Categoria")]
        [Required]
        public Categoria Categoria { get; set; }

        public ICollection<Prod_Car> ProdCar { get; set; }
    }
}
