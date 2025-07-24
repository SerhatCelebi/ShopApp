using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;
using System.Runtime.CompilerServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values=await _categoryServices.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var value=await _categoryServices.GetByIdCategoryAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryServices.CreateCategoryAsync(createCategoryDto);
            return Ok("Category Added");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryServices.DeleteCategoryAsync(id);
            return Ok("Category Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryServices.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Category Updated");
        }
    }
}
