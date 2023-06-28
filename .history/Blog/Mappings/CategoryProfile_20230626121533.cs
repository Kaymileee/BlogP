using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Models;

namespace Blog.Mappings
{
  public class CategoryProfile : Profile
  {
    public CategoryProfile()
    {
      CreateMap<CategoryFromCSV, CategoryCreateRequest>()
      .ForMember(dst => dst.Content, opt => opt.MapFrom(x => x.Body))
      .ForMember(dst => dst.ListTag, opt => opt.MapFrom(x => x.Tags))
      .ForMember(dst => dst.CreateDate, opt => opt.MapFrom(x => x.CreationDate));
    }

  }
}