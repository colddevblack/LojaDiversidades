using AutoMapper;
using LojaDiversidade.CartApi.Models;

namespace LojaDiversidade.CartApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CartDTO, Cart>().ReverseMap();
        CreateMap<CartHeaderDTO, CartHeader>().ReverseMap();
        CreateMap<CartItemDTO, CartItem>().ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
    }
}
