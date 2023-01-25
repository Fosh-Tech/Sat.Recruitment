using Sat.Recruitment.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task InsertAsync(TEntity entity, bool saveChanges = true);
        Task UpdateAsync(TEntity entity, bool saveChanges = true);
        Task DeleteAsync(object[] id, bool saveChanges = true);
        Task DeleteAsync(TEntity entity, bool saveChanges = true);
#warning "TXT MODE..."
        Task InsertTXTAsync(TEntity entity, bool saveChanges = true);
    }
}
