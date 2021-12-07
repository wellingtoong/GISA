using GISA.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GISA.Convenio.API.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<bool> Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task<bool> Atualizar(TEntity entity);
        //Task<bool> Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<bool> SaveChanges();
    }
}
