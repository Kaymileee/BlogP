using Blog.Models;

namespace Blog.Services;

public interface ITagService
{
  public Task AddTag();
  public Task<List<TagVMD>> GetTask();
  public Task UpdateTag(string? tagId);
  public Task DeleteTag(string? tagId);



}