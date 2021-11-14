using MediatR;
using Sample.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Features.Products.Commands
{
    public class UpdateProductStatusByCategoryIdCommand : INotification
    {
        public int CategoryId { get; set; }
        public decimal StockQuantity { get; set; }

        internal class UpdateProductStatusByCategoryIdCommandHandler : INotificationHandler<UpdateProductStatusByCategoryIdCommand>
        {
            private readonly IProductRepository _productRepository;

            public UpdateProductStatusByCategoryIdCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task Handle(UpdateProductStatusByCategoryIdCommand notification, CancellationToken cancellationToken)
            {
                await _productRepository.UpdateProductStatusByCategoryIdAsync(notification.CategoryId, notification.StockQuantity, cancellationToken);
            }
        }
    }
}
