using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public SatRecruitmentContext Context { get; }

        private IDbContextTransaction contextTransaction;
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(SatRecruitmentContext context)
        {
            Context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(this);
            return (IRepository<TEntity>)_repositories[type];
        }

        public async Task BeginTransactionAsync()
        {
            if (contextTransaction != null)
            {
                await contextTransaction.RollbackAsync();
                await contextTransaction.DisposeAsync();
                contextTransaction = null;
            }
            contextTransaction = await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await contextTransaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await contextTransaction.RollbackAsync();
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }

        #region Dispose
        // Used to determine if Dispose()
        // has already been called.
        private bool _disposed = false;

        /// <summary>
        /// Dispose method
        /// </su
        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        [ExcludeFromCodeCoverage]
        private void CleanUp(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Disposing();
                Context?.Dispose();
                contextTransaction?.Dispose();
            }
        }
        ~UnitOfWork()
        {
            CleanUp(false);
        }

        [ExcludeFromCodeCoverage]
        protected virtual void Disposing()
        {
        }
        #endregion
    }
}
