using Sample.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<T> Repository<T>() where T : BaseEntity;
        Task<int> Commit(CancellationToken cancellationToken);
        Task Rollback();
    }
}
