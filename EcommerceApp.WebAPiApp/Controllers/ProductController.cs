using ECommerceApp.ApplicationCore.Contracts.Service;
using ECommerceApp.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebAPiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productServiceAsync;

        public ProductController(IProductServiceAsync productServiceAsync)
        {
            this.productServiceAsync = productServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await productServiceAsync.GetAllProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequestModel model)
        { 
           var result = await productServiceAsync.InsertProductAsync(model);
            if (result > 0)
                return Ok("Product has been added successfully");
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await productServiceAsync.DeleteProductAsync(id);
            if (result > 0)
                return Ok("Product has been deleted successfully");
            return BadRequest();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(int id, ProductRequestModel model)
        {
            var result = await productServiceAsync.UpdateProductAsync(id, model);
            if (result > 0)
                return Ok("Product has been updated");
            else
                return NotFound();
        
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        { 
           var result = await productServiceAsync.GetProductByIdAsync(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        


    }
}
