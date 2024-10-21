using FoxFood.Data.Mapping;
using FoxFood.Dominio.Entites;
using Microsoft.EntityFrameworkCore;

namespace FoxFood.Data.Contexto
{
    public partial class FoxFoodContext : DbContext
    {
        public FoxFoodContext(DbContextOptions<FoxFoodContext> options)
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
