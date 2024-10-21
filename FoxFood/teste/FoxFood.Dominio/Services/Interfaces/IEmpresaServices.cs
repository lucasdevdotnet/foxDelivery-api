using FoxFood.Dominio.Entites;

namespace FoxFood.Dominio.Services.Interfaces
{
    public interface IEmpresaServices
    {
        Task Adicionar(Empresa empresa, CancellationToken cancellationToken);
        Task Edite(Empresa empresa);
        Task<List<Empresa>>? GetAll();
        Task<Empresa> ObterEmpresa(long id);
    }
}
