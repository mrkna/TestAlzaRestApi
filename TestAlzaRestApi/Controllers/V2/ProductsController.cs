using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAlzaRestApi.Models;

namespace TestAlzaRestApi.Controllers.V2
{
    [Produces("application/json")]
    [Route("api/v2/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductContext _context;
        private readonly int _defaultPageSize = 10;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Products
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Get all Products
        /// </summary>
        [HttpGet("page/{page}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsPaginationAsync(int page)
        {
            int startPosition = (page - 1) * _defaultPageSize;
            if(startPosition > _context.Products.Count())
            {
                return NotFound();
            }

            return await _context.Products.Skip(startPosition).Take(_defaultPageSize).ToListAsync();
        }

        /// <summary>
        /// Get a specific Product
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="200">Success</response>
        /// <response code="404">Product not found</response>  
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        /// <summary>
        /// Change description a specific Product
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "description": "Text describing the Product"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Product description changed</response>
        /// <response code="400">Bad request</response>  
        /// <response code="404">Product not found</response>  
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchProductAsync(int id, ProductDescription description)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Description = description.Description;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
