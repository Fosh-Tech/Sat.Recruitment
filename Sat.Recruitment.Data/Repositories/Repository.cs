using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UnitOfWork _unitOfWork;
        private DbSet<TEntity> _dbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
            _dbSet = _unitOfWork.Context.Set<TEntity>();
        }

        #region Async CRUD
        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }
        public async Task<TEntity> GetByIdAsync(object id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task InsertAsync(TEntity entity, bool saveChanges = true)
        {
            await _dbSet.AddAsync(entity);
            if (saveChanges)
                await _unitOfWork.SaveAsync();
        }

#warning "TXT MODE..."
        public async Task InsertTXTAsync(TEntity entity, bool saveChanges = true)
        {
            Debug.WriteLine("User Created");
            //...
            File.AppendAllText(@"..\Sat.Recruitment.Data\Files\Users.txt", Environment.NewLine + entity.ToString());

        }

        public async Task DeleteAsync(object[] id, bool saveChanges = true)
        {
            TEntity entity = await this.GetByIdAsync(id);
            await DeleteAsync(entity);
            if (saveChanges)
                await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(TEntity entity, bool saveChanges = true)
        {
            if (entity != null)
            {
                if (_unitOfWork.Context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
                if (saveChanges)
                    await _unitOfWork.SaveAsync();
            }
        }
        public async Task UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            if (saveChanges)
                await _unitOfWork.SaveAsync();
        }
        #endregion
    }
}
