using LuftballonAt.Models.Dtos.CategoryDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Utilities.MappingProfiles
{
    public class CategoryMapperProfile : AutoMapper.Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryNamesDto>()
                .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
