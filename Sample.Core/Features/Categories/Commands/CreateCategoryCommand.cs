using AutoMapper;
using MediatR;
using Sample.Core.Interfaces.Repositories;
using Sample.Domain.Entities;
using Sample.Shared.Models.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public decimal MinimumStockQuantity { get; set; }

        internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<Category>(request);

                var result = await _unitOfWork.Repository<Category>().AddAsync(category);
                await _unitOfWork.Commit(cancellationToken);

                return Result<int>.Success(result.Id);
            }
        }
    }
}
