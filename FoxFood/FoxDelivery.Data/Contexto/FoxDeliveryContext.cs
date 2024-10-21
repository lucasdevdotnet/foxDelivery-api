using FoxDelivery.Data.Mapping;
using FoxDelivery.Dominio.Entites;
using Microsoft.EntityFrameworkCore;

namespace FoxDelivery.Data.Contexto
{
    public partial class FoxDeliveryContext : DbContext
    {
        public FoxDeliveryContext(DbContextOptions<FoxDeliveryContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
        }
    }
}
