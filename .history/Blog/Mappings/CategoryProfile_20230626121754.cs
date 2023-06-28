using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Helpers;
using Blog.Models;

namespace Blog.Mappings
{
  public class CategoryProfile : Profile
  {
    public CategoryProfile()
    {
      CreateMap<CategoryFromCSV, CategoryCreateRequest>()
      .ForMember(dst => dst.Name, opt => opt.MapFrom(x => x.Name))
      .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.Name != null ? TextHelper.ToUnsignedString(x.Name) : ""))
      .ForMember(dst => dst.Parent, opt => opt.MapFrom(x => TextHelper.ToUnsignedString(x.Parent)));
    }

  }
}