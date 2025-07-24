using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoCustomerList()
        {
            var values = await _cargoCustomerService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoCustomerById(int id)
        {
            var value = await _cargoCustomerService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer CargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City=createCargoCustomerDto.City,
                District=createCargoCustomerDto.District,
                Email=createCargoCustomerDto.Email,
                Name=createCargoCustomerDto.Name,
                Phone=createCargoCustomerDto.Phone,
                Surname=createCargoCustomerDto.Surname,
                
            };
            await _cargoCustomerService.TInsertAsync(CargoCustomer);
            return Ok("Cargo Customer Added");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCustomer(int id)
        {
            await _cargoCustomerService.TDeleteAsync(id);
            return Ok("Cargo Customer Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer CargoCustomer = new CargoCustomer()
            {
                CargoCustomerId= updateCargoCustomerDto.CargoCustomerId,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname,
            };
            await _cargoCustomerService.TUpdateAsync(CargoCustomer);
            return Ok("Cargo Customer Updated");
        }
    }
}
