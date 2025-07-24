using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountServices _discountServices;

        public DiscountsController(IDiscountServices discountServices)
        {
            _discountServices = discountServices;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values=await _discountServices.GetAllDiscountCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        {
            var value=await _discountServices.GetByIdDiscountCouponAsync(id);
            return Ok(value);

        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCoupon)
        {
            await _discountServices.CreateDiscountCouponAsync(createCoupon);
            return Ok("Coupon Added");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountServices.DeleteDiscountCouponAsync(id);
            return Ok("Coupon Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCoupon)
        {
            await _discountServices.UpdateDiscountCouponAsync(updateCoupon);
            return Ok("Coupon Updated");
        }
    }
}
