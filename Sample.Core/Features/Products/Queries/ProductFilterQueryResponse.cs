using Sample.Domain.Entities;
using System.Collections.Generic;

namespace Sample.Core.Features.Products.Queries
{
    public class ProductFilterQueryResponse
    {
        public IEnumerable<Product> Results { get; set; }
    }
}
