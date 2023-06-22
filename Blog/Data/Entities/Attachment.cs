using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Blog.Data.Entities
{
  public class Attachment
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string? FileName { get; set; }

    [Required]
    [MaxLength(255)]
    public string? FilePath { get; set; }

    [Required]
    [MaxLength(4)]
    public string? FileType { get; set; }

    [Required]
    public long FileSize { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    [JsonIgnore]
    public Post? Post { get; set; }

    [Required]
    public int PostId { get; set; }

  }
}
