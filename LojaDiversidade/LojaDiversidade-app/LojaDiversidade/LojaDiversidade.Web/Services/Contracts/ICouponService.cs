using LojaDiversidade.Web.Models;

namespace LojaDiversidade.Web.Services.Contracts;

public interface ICouponService
{
    Task<CouponViewModel> GetDiscountCoupon(string couponCode, string token);
}
