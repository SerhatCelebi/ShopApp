using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System.Runtime.CompilerServices;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values=await _cargoCompanyService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCompanyById(int id)
        {
            var value=await _cargoCompanyService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany=new CargoCompany(){ 
                CargoCompanyName=createCargoCompanyDto.CargoCompanyName
                };
            await _cargoCompanyService.TInsertAsync(cargoCompany);
            return Ok("Cargo Company Added");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCompany(int id)
        {
            await _cargoCompanyService.TDeleteAsync(id);
            return Ok("Cargo Company Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany=new CargoCompany()
            {
                CargoCompanyId=updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName=updateCargoCompanyDto.CargoCompanyName
            };
            await _cargoCompanyService.TUpdateAsync(cargoCompany);
            return Ok("Cargo Company Updated");
        }
    }
}
