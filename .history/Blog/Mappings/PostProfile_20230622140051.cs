using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Blog.Mappings
{
  public class PostProfile : Profile
  {
    CreateMap<PostCreateRequest, PostFromCSV>(){

        }
}
}