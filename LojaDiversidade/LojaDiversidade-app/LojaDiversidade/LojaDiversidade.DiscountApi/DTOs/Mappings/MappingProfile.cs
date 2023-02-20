using AutoMapper;
using LojaDiversidade.DiscountApi.Models;

namespace LojaDiversidade.DiscountApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CouponDTO, Coupon>().ReverseMap();
    }
}
