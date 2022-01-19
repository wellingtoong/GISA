using GISA.Core.Data;
using GISA.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GISA.Pessoa.API.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) 
            => await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        public virtual async Task<TEntity> ObterPorId(Guid id) => await DbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> ObterTodos() => await DbSet.ToListAsync();

        public virtual async Task<bool> Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            return await SaveChanges();
        }

        public virtual async Task<bool> Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            return await SaveChanges();
        }

        public async Task<bool> SaveChanges() => await Db.SaveChangesAsync() > 0;

        public void Dispose() => Db?.Dispose();
    }
}