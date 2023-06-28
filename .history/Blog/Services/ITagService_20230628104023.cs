using Blog.Models;

namespace Blog.Services;

public interface ITagService
{
  public Task AddTag();
  public Task<List<TagVMD>> GetAllTag();
  public Task<TagVMD> GetTagById(string? tagId);

  public Task UpdateTag(string? tagId);
  public Task DeleteTag(string? tagId);



}