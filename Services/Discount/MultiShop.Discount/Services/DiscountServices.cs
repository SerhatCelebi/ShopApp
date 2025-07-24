using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MultiShop.Discount.Services
{
    public class DiscountServices : IDiscountServices
    {
        private readonly DapperContext _context;

        public DiscountServices(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query= "insert into Coupons (CouponCode,CouponRate,CouponIsActive,CouponValidDate) values (@couponcode,@couponrate,@couponisactive,@couponvaliddate)";
            var parameters=new DynamicParameters();
            parameters.Add("@couponcode",createCouponDto.CouponCode);
            parameters.Add("@couponrate",createCouponDto.CouponRate);
            parameters.Add("@couponisactive",createCouponDto.CouponIsActive);
            parameters.Add("couponvaliddate",createCouponDto.CouponValidDate);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query="Delete From Coupons Where CouponId=@couponId";
            var parameters=new DynamicParameters();
            parameters.Add("couponId",id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query="Select * From Coupons";
            using(var connection = _context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query="Select * From Coupons Where CouponId=@couponId";
            var parameters=new DynamicParameters();
            parameters.Add("@couponId",id);
            using(var connection = _context.CreateConnection())
            {
                var value=await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return value;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query="Update Coupons Set CouponCode=@couponcode,CouponRate=@couponrate,CouponIsActive=@couponisactive,CouponValidDate=@couponvaliddate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId",updateCouponDto.CouponId);
            parameters.Add("@couponcode", updateCouponDto.CouponCode);
            parameters.Add("@couponrate", updateCouponDto.CouponRate);
            parameters.Add("@couponisactive", updateCouponDto.CouponIsActive);
            parameters.Add("couponvaliddate", updateCouponDto.CouponValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
