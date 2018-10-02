using System;
using System.Linq;
using System.Linq.Expressions;
using Kanban.Infra.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Infra.Database.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected KanbanContext Context { get; private set; }

        public GenericRepository(KanbanContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}