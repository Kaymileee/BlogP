using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.Entities;
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
      .ForMember(dst => dst.Parent, opt => opt.MapFrom(x => x.Parent != null ? TextHelper.ToUnsignedString(x.Parent) : null));

      CreateMap<CategoryFromCSV, Category>()
      .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(x => x.Name))
      .ForMember(dst => dst.Description, opt => opt.MapFrom(x => x.Name))
      .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(x => x.Name != null ? TextHelper.ToUnsignedString(x.Name) : ""))
      .ForMember(dst => dst.ParentId, opt => opt.MapFrom(x => x.Parent != null ? TextHelper.ToUnsignedString(x.Parent) : null));
    }

  }
}