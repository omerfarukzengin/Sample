using AutoMapper;
using MediatR;
using Sample.Core.Features.Products.Commands;
using Sample.Core.Interfaces.Repositories;
using Sample.Domain.Entities;
using Sample.Shared.Models.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Features.Categories.Commands
{
    public class UpdateCategoryCommand : CreateCategoryCommand
    {
        public int Id { get; set; }

        internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<Category>(request);

                await _unitOfWork.Repository<Category>().UpdateAsync(category);
                await _unitOfWork.Commit(cancellationToken);

                await _mediator.Publish(new UpdateProductStatusByCategoryIdCommand
                {
                    CategoryId = category.Id,
                    StockQuantity = category.MinimumStockQuantity
                }, cancellationToken);

                return Result<int>.Success(category.Id);
            }
        }
    }
}
