using MediatR;
using Sample.Core.Interfaces.Repositories;
using Sample.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Core.Features.Products.Queries
{
    public class GetAllQuery : IRequest<ProductFilterQueryResponse>
    {
        internal class GetAllProductsQueryHandler : IRequestHandler<GetAllQuery, ProductFilterQueryResponse>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<ProductFilterQueryResponse> Handle(GetAllQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<Product> entities = _unitOfWork.Repository<Product>().Entities;

                ProductFilterQueryResponse response = new ProductFilterQueryResponse
                {
                    Results = entities
                };

                return Task.FromResult(response);
            }
        }
    }
}
