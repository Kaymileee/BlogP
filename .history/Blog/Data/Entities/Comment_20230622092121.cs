﻿using System.Text.Json.Serialization;

namespace Blog.Data.Entities
{
  public class Comment
  {
    public int? CommentId { get; set; }
    public string? Title { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Content { get; set; }
    [JsonIgnore]
    public Post? Post { get; set; }
    public int? PostId { get; set; }
  }
}