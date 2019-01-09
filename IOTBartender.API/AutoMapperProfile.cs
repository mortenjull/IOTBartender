using AutoMapper;
using IOTBartender.API.Models.Entities;
using IOTBartender.Domain.Entititeis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartender.API
{
    public class AutoMapperProfile
        : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Fluid, FluidModel>();
            CreateMap<Component, ComponentModel>();
            CreateMap<Recipe, RecipeModel>();
            CreateMap<Order, OrderModel>()
                .ForMember(member => member.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
