using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.Entities;
using Blog.Models;

namespace Blog.Mappings
{
  public class PostProfile : Profile
  {
    public PostProfile()
    {
      CreateMap<PostFromCSV, PostCreateRequest>()
      .ForMember(dst => dst.Content, opt => opt.MapFrom(x => x.Body))
      .ForMember(dst => dst.ListTag, opt => opt.MapFrom(x => x.Tags))
      .ForMember(dst => dst.CreateDate, opt => opt.MapFrom(x => x.CreationDate));

      CreateMap<Post, PostFromCSV>()
      .ForMember(dst => dst.Body, opt => opt.MapFrom(x => x.Content))
      .ForMember(dst => dst.Tags, opt => opt.MapFrom(x => x.ListTag))
      .ForMember(dst => dst.CreationDate, opt => opt.MapFrom(x => x.CreatedDate));
    }

    public string[] Split(string str)
    {
      return str.Split(',');
    }

  }
}