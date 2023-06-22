namespace Blog.Models;

public class PostFromCSV
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string[]? Tags { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Y { get; set; }
}