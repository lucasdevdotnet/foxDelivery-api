using FoxDelivery.Data.Contexto;
using FoxDelivery.Dominio.Entites;
using FoxDelivery.Dominio.Repositories.Interfaces;

namespace FoxDelivery.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        private readonly FoxDeliveryContext context;

        public EmpresaRepository(FoxDeliveryContext _context)
         : base(_context)
        {
            context = _context;
        }
    }
}
