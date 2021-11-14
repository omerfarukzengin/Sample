using AutoMapper;
using MediatR;
using Sample.Core.Interfaces.Repositories;
using Sample.Domain.Entities;
using Sample.Shared.Models.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Result<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal Quantity { get; set; }
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            if (request.CategoryId > 0)
            {
                var category = await _unitOfWork.Repository<Category>().GetByIdAsync((int)product.CategoryId);
                product.Active = product.Quantity > category.MinimumStockQuantity;
            }

            var result = await _unitOfWork.Repository<Product>().AddAsync(product);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(result.Id);
        }
    }
}
