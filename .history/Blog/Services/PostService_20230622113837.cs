using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Entities;
using Blog.Helpers;
using Blog.Models;
using Blog.Models.EF;
using Microsoft.VisualBasic.FileIO;

namespace Blog.Services
{
  public class PostService : IPostService
  {
    private readonly ApplicationDBContext _context;

    public PostService(ApplicationDBContext context)
    {
      _context = context;
    }

    public List<PostFromCSV> GetData(string filePath)
    {
      using (TextFieldParser parser = new TextFieldParser(filePath))
      {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        // skip the header line
        parser.ReadLine();
        int idCounter = 1;

        List<PostFromCSV> dataList = new List<PostFromCSV>();
        while (!parser.EndOfData)
        {
          string[] fields = parser.ReadFields();
          PostFromCSV data = new PostFromCSV();
          data.Id = int.Parse(fields[0]);
          data.Title = fields[1];
          data.Body = fields[2];
          data.Tags = fields[3].Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
          data.CreationDate = DateTime.ParseExact(fields[4], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
          data.Y = fields[5];
          dataList.Add(data);
          idCounter++;
        }
        return dataList;
      }
    }

    private static Post CreatePostEntity(PostCreateRequest request)
    {
      var entity = new Post()
      {
        UserId = request.UserId,
        Title = request.Title,
        Slug = TextHelper.ToUnsignedString(request.Title != null ? request.Title : ""),
        Content = request.Content,
      };
      if (request.ListTag?.Length > 0)
      {
        entity.ListTag = string.Join(',', request.ListTag);
      }
      return entity;
    }

    private async Task ProcessTag(PostCreateRequest request, Post post)
    {
      if (request.ListTag != null)
      {
        foreach (var labelText in request.ListTag)
        {
          if (labelText == null) continue;
          var TagId = TextHelper.ToUnsignedString(labelText.ToString());
          var existingLabel = await _context.Tags.FindAsync(TagId);
          if (existingLabel == null)
          {
            var tag = new Tag()
            {
              TagId = TagId,
              TagName = labelText.ToString()
            };
            _context.Tags.Add(tag);
          }
          if (await _context.PostTags.FindAsync(post.PostId, TagId) == null)
          {
            _context.PostTags.Add(new PostTag()
            {
              PostId = post.PostId,
              TagId = TagId
            });
          }
        }
      }
    }

    public async Task SeedData(List<PostCreateRequest> requests, Guid userId)
    {
      foreach (var request in requests)
      {
        request.UserId = userId;
        Post post = CreatePostEntity(request);
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();

        //Process label
        if (request.ListTag?.Length > 0)
        {
          await ProcessTag(request, post);
        }
        var result = await _context.SaveChangesAsync();
      }
    }
  }
}