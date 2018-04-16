using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PhoneBookTestApp
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbSet<T> _dbSet;
        private MyDatabaseEntities _dbContext;
        public Repository(MyDatabaseEntities dbcontext)
        {
            _dbContext = dbcontext;
            _dbSet = _dbContext.Set<T>();
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
        {
            return _dbSet.Where(whereCondition).ToList();
        }

        public bool Add(T entity)
        {
            _dbSet.Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            return true;
        }
    }
}
