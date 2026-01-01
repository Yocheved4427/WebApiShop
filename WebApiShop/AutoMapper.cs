using AutoMapper;
using DTOs;
using Entities;

namespace WebApiShop
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, ExisitingUserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>();

        }
    }
}