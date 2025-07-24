using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoOperationList()
        {
            var values = await _cargoOperationService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoOperationById(int id)
        {
            var value = await _cargoOperationService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Description=createCargoOperationDto.Description,
                Barcode=createCargoOperationDto.Barcode,
                OperationDate=createCargoOperationDto.OperationDate
            };
            await _cargoOperationService.TInsertAsync(cargoOperation);
            return Ok("Cargo Operation Added");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoOperation(int id)
        {
            await _cargoOperationService.TDeleteAsync(id);
            return Ok("Cargo Operation Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Description = updateCargoOperationDto.Description,
                Barcode = updateCargoOperationDto.Barcode,
                OperationDate = updateCargoOperationDto.OperationDate,
                CargoOperationId=updateCargoOperationDto.CargoOperationId
            };
            await _cargoOperationService.TUpdateAsync(cargoOperation);
            return Ok("Cargo Operation Updated");
        }
    }
}
