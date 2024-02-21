using LuftballonAt.Models.Dtos.ProductDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Utilities.MappingProfiles
{
    public class ProductMapperProfile : AutoMapper.Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();

        }
    }
}
