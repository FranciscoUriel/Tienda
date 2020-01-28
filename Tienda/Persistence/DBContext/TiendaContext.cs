using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tienda.Persistence.DBContext
{
    public class TiendaContext : IdentityDbContext<Usuarios>
    {
        public TiendaContext (DbContextOptions<TiendaContext> options) : base(options) 
        {
        
        }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Prod_Car> ProdCar { get; set; }
        public DbSet<Categoria> Categroria { get; set; }
        public DbSet<Sale> Sale { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
