using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;


namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailServices;

        public ProductDetailsController(IProductDetailServices productDetailServices)
        {
            _productDetailServices = productDetailServices;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailServices.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value =await _productDetailServices.GetByIdProductDetailAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailServices.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Product Detail Added");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailServices.DeleteProductDetailAsync(id);
            return Ok("Product Detail Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailServices.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Product Detail Updated");
        }
    }
}
