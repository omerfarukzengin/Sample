using Sample.Core.Interfaces.Repositories;
using Sample.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepositoryAsync<Product> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductRepository(IRepositoryAsync<Product> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateProductStatusByCategoryIdAsync(int categoryId, decimal quantity, CancellationToken cancellationToken)
        {
            var inActives = _repository.Entities.Where(b => b.CategoryId == categoryId).ToList();

            foreach (var inActive in inActives)
            {
                inActive.Active = inActive.Quantity > quantity;
                await _repository.UpdateAsync(inActive);
            }
            await _unitOfWork.Commit(cancellationToken);
        }
    }
}
