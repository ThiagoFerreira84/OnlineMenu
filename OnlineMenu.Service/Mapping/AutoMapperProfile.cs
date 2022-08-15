using AutoMapper;
using OnlineMenu.Model;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, VMCategory>().ReverseMap();
            CreateMap<Item, VMItem>().ReverseMap();
            CreateMap<SubCategory, VMSubCategory>().ReverseMap();
            CreateMap<Order, VMOrder>().ReverseMap();
            CreateMap<OrderItem, VMOrderItem>().ReverseMap();
            CreateMap<Restaurant, VMRestaurant>().ReverseMap();
            CreateMap<Subscription, VMSubscription>().ReverseMap();
            CreateMap<Table, VMTable>().ReverseMap();
            CreateMap<User, VMUser>().ReverseMap();
            CreateMap<UserType, VMUserType>().ReverseMap();
            CreateMap<Country, VMCountry>().ReverseMap();
            CreateMap<ViewRestaurant, VMViewRestaurant>().ReverseMap();
        }
    }
}