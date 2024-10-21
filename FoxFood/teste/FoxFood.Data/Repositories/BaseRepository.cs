using FoxFood.Data.Contexto;
using FoxFood.Dominio.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoxFood.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly FoxFoodContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(FoxFoodContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
    
        public virtual async Task<List<TEntity>> ListarTodos(int pagina = 0, int nrItensPorPagina = 0)
        {
            var consulta = from x in DbSet
                           .OrderBy(x => (true))
                           select x;

            if (pagina == 0 && nrItensPorPagina == 0)
            {
                return await consulta.ToListAsync();
            }
            else
            {
                return await consulta.Skip((pagina - 1) * nrItensPorPagina)
                               .Take(nrItensPorPagina)
                               .ToListAsync();
            }
        }

        #region Quantidade
        /// <summary>
        /// Obtém a quantidade de registos da Entity na base
        /// </summary>
        /// <returns>Quantidade de registros da Entity na base</returns>
        public async Task<int> Quantidade()
        {
            var consulta = DbSet;

            return await consulta.CountAsync();
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Insere um novo Objeto no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual async Task<TEntity> Adicionar(TEntity entidade)
        {
            await DbSet.AddAsync(entidade);
            return entidade;
        }
        #endregion

        #region ObterPorChave
        /// <summary>
        /// Obtém uma Entity apartir de sua chave
        /// </summary>
        /// <param name="chave">Chave de identificação da Entity</param>
        /// <returns>Entidade requisitada</returns>
        public virtual async Task<TEntity> ObterPorChave(long chave)
        {
            var consulta = DbSet.FindAsync(chave);
            return await consulta;
        }
        #endregion

        #region Find
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Altera uma Entity no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual async Task Alterar(TEntity entidade)
        {
            DbSet.Update(entidade);

        }
        #endregion

        #region Excluir
        /// <summary>
        /// Exclui uma Entity do contexto
        /// </summary>
        /// <param name="chave">Chave de identificação da Entity</param>
        public virtual void Excluir(TEntity entidade)
        {
            //TEntity entity = ObterPorChave(chave);
            //DbSet.Remove(entity);
            try
            {
                DbSet.Remove(entidade);

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Salvar
        /// <summary>
        /// Salva as alterações do contexto na base de dados
        /// </summary>
        /// <returns>Numero de linhas afetadas. Se não conseguir executar nada retorna negativo.</returns>
        public async Task<int> Salvar()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (Exception e)
            { 

                throw e;
            }
            return Db.SaveChanges();
        }

        #endregion

        public void Dispose()
        {
            Db.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}

