using System.Linq.Expressions;

namespace FoxDelivery.Dominio.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        #region Base Padrão
        //void Add(TEntity obj);
        //TEntity GetById(Guid id);
        //IQueryable<TEntity> GetAll();
        //void Update(TEntity obj);
        //void Remove(Guid id);
        //int SaveChanges();
        #endregion

        #region ListarTodos
        /// <summary>
        /// Obtém todos os objeto do tipo da Entity da base
        /// </summary>
        /// <param name="pagina">identificação da paginação da pagina</param>
        /// <param name="nrItensPorPagina">Numero de item por pagina</param>
        /// <returns>Lista da Entity</returns>
        Task<List<TEntity>> ListarTodos(int pagina = 0, int nrItensPorPagina = 0);
        #endregion

        #region Quantidade
        /// <summary>
        /// Obtém a quantidade de registos da Entity na base
        /// </summary>
        /// <returns>Quantidade de registros da Entity na base</returns>
        Task<int> Quantidade();

        #endregion

        #region Inserir
        /// <summary>
        /// Insere um novo Objeto no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        Task<TEntity> Adicionar(TEntity entidade);

        #endregion

        #region ObterPorChave
        /// <summary>
        /// Obtém uma Entity apartir de sua chave
        /// </summary>
        /// <param name="chave">Chave de identificação da Entity</param>
        /// <returns>Entidade requisitada</returns>
        Task<TEntity> ObterPorChave(long chave);
        #endregion

        #region Find
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Alterar
        /// <summary>
        /// Altera uma Entity no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        Task Alterar(TEntity entidade);

        #endregion

        #region Excluir
        /// <summary>
        /// Exclui uma Entity do contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        void Excluir(TEntity entidade);

        #endregion

        #region Salvar
        /// <summary>
        /// Salva as alterações do contexto na base de dados
        /// </summary>
        /// <returns>Numero de linhas afetadas. Se não conseguir executar nada retorna negativo.</returns>
        Task<int> Salvar();


        #endregion

        #region Dispose
        void Dispose();
        #endregion

    }
}
