using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
