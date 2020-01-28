using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tienda.Persistence.DBContext;
using Tienda.Persistence.Entities;

namespace Tienda
{
    [Authorize(Roles = "Administrador")]
    public class IndexCatModel : PageModel
    {
        private readonly Tienda.Persistence.DBContext.TiendaContext _context;

        public IndexCatModel(Tienda.Persistence.DBContext.TiendaContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categoria { get;set; }

        public async Task OnGetAsync()
        {
            Categoria = await _context.Categroria.ToListAsync();
        }
    }
}
