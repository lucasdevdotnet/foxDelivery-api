using Microsoft.Extensions.DependencyInjection;
using SFCredito.Data.Repositories;
using SFCredito.Dominio.Repositories.Interfaces;

namespace SFCredito.Data
{
    public static class DependencyInjectionData
    {
        public static void RegisterData(this IServiceCollection services)
        {
            services.AddScoped<IDocumentoClienteRepository, DocumentoClienteRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IAnalisePropostaRepository, AnalisePropostaRepository>();
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<ICartelaClienteFinanceiraRepository, CartelaClienteFinanceiraRepository>();
            services.AddScoped<IControleProducaoRepository, ControleProducaoRepository>();
            services.AddScoped<IDigitacaoRepository, DigitacaoRepository>();
            services.AddScoped<IDocumentoAssinaturaRepository, DocumentoAssinaturaRepository>();
            services.AddScoped<IPreAgendamentoRepository, PreAgendamentoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ISimulacaoBancoRepository, SimulacaoBancoRepository>();
            services.AddScoped<ISituacaoControleProducaoRepository, SituacaoControleProducaoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<ISimulacaoRepository, SimulacaoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPerfilUsuarioRepository,PerfilUsuarioRepository>();
            services.AddScoped<IProdutoBancoRepository, ProdutoBancoRepository>();
            services.AddScoped<ISituacaoCreditoRepository, SituacaoCreditoRepository>();
            services.AddScoped<ISituacaoPropostaRepository, SituacaoPropostaRepository>();
            services.AddScoped<ITelaTransacaoRepository, TelaTransacaoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ITipoBeneficioRepository, TipoBeneficioRepository>();
            services.AddScoped<ITransacaoPerfilRepository, TransacaoPerfilRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
