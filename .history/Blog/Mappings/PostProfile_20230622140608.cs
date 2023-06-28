using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Models;

namespace Blog.Mappings
{
  public class PostProfile : Profile
  {
    public PostProfile()
    {
      CreateMap<PostCreateRequest, PostFromCSV>()
      .ForMember(dst => dst.Title, opt => opt.MapFrom(x => x.Title));

      CreateMap<PostFromCSV, PostCreateRequest>()
      .ForMember(dst => dst.Title, opt => opt.MapFrom(x => x.Title));
    }

  }
}