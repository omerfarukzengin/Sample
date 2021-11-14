using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Core.Features.Products.Commands;
using Sample.Core.Features.Products.Queries;
using Sample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ODataController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Product>> GetAll()
        {
            var response = await _mediator.Send(new GetAllQuery());
            return response.Results;
        }

        /// <summary>
        /// Add a Product
        /// </summary>
        /// <param name="productCommand"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProduct(CreateProductCommand productCommand)
        {
            var result = await _mediator.Send(productCommand);
            return Ok(result);
        }

    }
}
