using CaseStudy.Application.Products.Commands.DeleteProduct;
using CaseStudy.Application.Products.Commands.PostProduct;
using CaseStudy.Application.Products.Commands.UpdateProduct;
using CaseStudy.Application.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CaseStudy.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Find product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        public async Task<IActionResult> GetAsync(string id)
        {
            _logger.LogInformation("");
            var query = new GetProductQuery(id);
            _logger.LogTrace("");
            var product = await _mediator.Send(query);
            if (product == null)
            {
                _logger.LogWarning("");
                return NotFound();
            }
            _logger.LogInformation("");
            return Ok(product);
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        public async Task<IActionResult> PostAsync([FromBody] PostProductCommand command)
        {
            _logger.LogInformation("");
            var result = await _mediator.Send(command);
            _logger.LogInformation("");
            return Created(string.Empty, result);
        }

        /// <summary>
        /// Update product by id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(404, Type = typeof(NotFoundResult))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommand command)
        {
            _logger.LogInformation("");
            await _mediator.Send(command);
            _logger.LogInformation("");
            return Ok();
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(404, Type = typeof(NotFoundResult))]
        [ProducesResponseType(500, Type = typeof(Exception))]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            _logger.LogInformation("");
            var command = new DeleteProductCommand(id);
            await _mediator.Send(command);
            _logger.LogInformation("");
            return Ok();
        }
    }
}