namespace MultiShop.Discount.Dtos
{
    public class GetByIdDiscountCouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int CouponRate { get; set; }
        public bool CouponIsActive { get; set; }
        public DateTime CouponValidDate { get; set; }
    }
}
