using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services
{
  public class TagService : ITagService
  {
    private readonly ApplicationDBContext _dbContext;
    public TagService(ApplicationDBContext dbContext)
    {
      _dbContext = dbContext;
    }
    public Task AddTag()
    {
      throw new NotImplementedException();
    }

    public Task DeleteTag(string? tagId)
    {
      throw new NotImplementedException();
    }

    public async Task<List<TagVMD>> GetAllTag()
    {
      var tags = await _dbContext.Tags.Take(10).Select(u => new TagVMD()
      {
        TagId = u.TagId,
        TagName = u.TagName,
      }).ToListAsync();

      return tags

    }

    public Task<TagVMD> GetTagById(string? tagId)
    {
      throw new NotImplementedException();
    }

    public Task UpdateTag(string? tagId)
    {
      throw new NotImplementedException();
    }
  }
}