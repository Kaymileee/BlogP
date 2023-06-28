using Blog.Models;

namespace Blog.Services;

public interface ICategoryService
{
  List<CategoryFromCSV> GetData(string filePath);
  // Task SeedData(List<PostCreateRequest> requests, Guid? userId);
}