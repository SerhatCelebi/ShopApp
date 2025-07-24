using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;


namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            var values = await _cargoDetailService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoDetailById(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
                SenderCustomer=createCargoDetailDto.SenderCustomer,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId,
            };
            await _cargoDetailService.TInsertAsync(cargoDetail);
            return Ok("Cargo Detail Added");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoDetail(int id)
        {
            await _cargoDetailService.TDeleteAsync(id);
            return Ok("Cargo Detail Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = updateCargoDetailDto.Barcode,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                CargoDetailId=updateCargoDetailDto.CargoDetailId
            };
            await _cargoDetailService.TUpdateAsync(cargoDetail);
            return Ok("Cargo Detail Updated");
        }
    }
}
