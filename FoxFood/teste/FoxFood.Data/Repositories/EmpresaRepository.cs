using FoxFood.Data.Contexto;
using FoxFood.Dominio.Entites;
using FoxFood.Dominio.Repositories.Interfaces;

namespace FoxFood.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        private readonly FoxFoodContext context;

        public EmpresaRepository(FoxFoodContext _context)
         : base(_context)
        {
            context = _context;
        }
    }
}
