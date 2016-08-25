using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetFundamentals.Repository
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> GetList();
        T GetById(Expression<Func<T, bool>> match);
    }
}
