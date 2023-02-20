using LojaDiversidade.DiscountApi.DTOs;

namespace LojaDiversidade.DiscountApi.Repositories;

public interface ICouponRepository
{
    Task<CouponDTO> GetCouponByCode(string couponCode);
}
