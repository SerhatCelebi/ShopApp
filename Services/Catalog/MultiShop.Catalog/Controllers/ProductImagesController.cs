using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageServices _productImageServices;

        public ProductImagesController(IProductImageServices ProductImageServices)
        {
            _productImageServices = ProductImageServices;
        }
        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageServices.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _productImageServices.GetByIdProductImageAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageServices.CreateProductImageAsync(createProductImageDto);
            return Ok("Product Image Added");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageServices.DeleteProductImageAsync(id);
            return Ok("Product Image Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageServices.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Product Image Updated");
        }
    }
}
