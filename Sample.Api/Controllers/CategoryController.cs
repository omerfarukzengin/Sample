using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Core.Features.Categories.Commands;
using System.Threading.Tasks;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand categoryCommand)
        {
            var result = await _mediator.Send(categoryCommand);
            return Ok(result);
        }
        [HttpPut("{id}:int")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryCommand categoryCommand)
        {
            categoryCommand.Id = id;
            var result = await _mediator.Send(categoryCommand);
            return Ok(result);
        }
    }
}
