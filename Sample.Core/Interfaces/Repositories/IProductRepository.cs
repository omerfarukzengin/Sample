using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task UpdateProductStatusByCategoryIdAsync(int categoryId, decimal quantity, CancellationToken cancellationToken);
    }
}
