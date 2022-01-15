using CaseStudy.Application.Categories.Commands.DeleteCategory;
using CaseStudy.Application.Categories.Commands.PostCategory;
using CaseStudy.Application.Categories.Commands.UpdateCategory;
using CaseStudy.Application.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CaseStudy.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Find category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        public async Task<IActionResult> GetAsync(string id)
        {
            _logger.LogInformation("");//Loglama at
            var query = new GetCategoryQuery(id);
            var category = await _mediator.Send(query);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        public async Task<IActionResult> PostAsync([FromBody] PostCategoryCommand command)
        {
            _logger.LogInformation("");//Loglama at
            var result = await _mediator.Send(command);
            return CreatedAtRoute("GetCategoryById", new { version = "1", id = result.Id }, result);
        }

        /// <summary>
        /// Update category by id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(404, Type = typeof(NotFoundResult))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(404, Type = typeof(NotFoundResult))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var command = new DeleteCategoryCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}