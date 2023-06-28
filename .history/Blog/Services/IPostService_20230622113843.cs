using Blog.Models;

namespace Blog.Services;

public interface IPostService
{
  List<PostFromCSV> GetData(string filePath);
  Task SeedData(List<PostCreateRequest> requests, Guid userId);
}