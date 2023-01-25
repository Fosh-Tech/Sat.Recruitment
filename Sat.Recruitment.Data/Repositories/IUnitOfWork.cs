using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        //public SatRecruitmentContext Context { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> SaveAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
