using AutoMapper;

using LuftballonAt.Models.Dtos.ShoppingCartDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Utilities.MappingProfiles
{
    public class ShoppingCartItemMapperProfile : Profile
    {
        public ShoppingCartItemMapperProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartItemDto>().ReverseMap();

        }
    }
}
