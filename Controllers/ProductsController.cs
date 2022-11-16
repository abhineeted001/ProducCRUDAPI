using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCRUDAPI.Models;

namespace ProductCRUDAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDBContext _context;

        public ProductsController(ProductDBContext context)
        {
            _context = context;
        }
        #region Get Products

        //[Route("[Controller]")]
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>


        [HttpGet] //Returns all products details
        
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }
        #endregion

        #region Get specific Product by ID

        //[Route("[Controller]")]
        /// <summary>
        /// Get specific Product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")] //Returns specified product details
        
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        #endregion

        #region Add new Product

        //[Route("[Controller]/Create")]
        /// <summary>
        /// Add new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>


        [HttpPost] //Add new product
        
        public async Task<IActionResult> Post(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        #endregion

        #region Update Product by ID

        /// <summary>
        /// Update Product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productData"></param>
        /// <returns></returns>


        [HttpPut("{id}")] //Update product details by ID
        
        public async Task<IActionResult> Put(int? id, Product productData)
        {
            if (id == null || id == 0)
                return BadRequest();

            var product = await _context.Products.FindAsync(productData.Id);
            if (product == null)
                return NotFound();
            product.Name = productData.Name;
            product.Description = productData.Description;
            product.Price = productData.Price;
            await _context.SaveChangesAsync();
            return Ok();
        }

        #endregion

        #region Delete Product by ID

        //[Route("[Controller]/Delete")]
        /// <summary>
        /// Delete Product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpDelete("{id}")] //Delete user by ID
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Products.FindAsync(id);
            if (product == null) 
                return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();

        }

        #endregion
    }
}
