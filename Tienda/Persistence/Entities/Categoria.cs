using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Persistence.Entities
{
    public class Categoria
    {
        [Display(Name ="Categoria")]
        [Required]
        [Key]
        public string NomCategoria { get; set; }
        [Display(Name = "Detalles")]
        public string Detalle { get; set; }

        public ICollection<Producto> Producto { get; set; }
       
    }
   
}
