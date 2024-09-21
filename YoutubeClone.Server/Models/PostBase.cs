using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoutubeClone.Server.Models;

public enum PostType
{
    Video,
    Community
}

public abstract class PostBase
{
    [Key]
    public string Id { get; set; }
    
    public abstract PostType Type { get; set; }
    
    [ForeignKey("OwnerId")]
    public User Owner { get; init; }
    public Guid? OwnerId { get; set; }
    
    [MaxLength(5000)]
    public string Body { get; set; }

    public List<string> Captions { get; init; } = null!;
    
    public DateTime CreatedAt { get; init; }
    
    public ICollection<Rating> Ratings { get; set; } = null!;
}