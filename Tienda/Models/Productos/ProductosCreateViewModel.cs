using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Models.Productos
{
    public class ProductosCreateViewModel
    {
        [Display(Name = "Producto")]
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
        public string Categoria { get; set; }
        [Display(Name = "Direccion de la imagen")]
        [Required]
        public string Img { get; set; }
    }
}
