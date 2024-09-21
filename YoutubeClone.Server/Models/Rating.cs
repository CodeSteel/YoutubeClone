using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoutubeClone.Server.Models;

public enum RatingType
{
    Like,
    Dislike
}

public class Rating
{
    [Key]
    public Guid Id { get; set; }
    
    public User Owner { get; set; }

    [ForeignKey("PostId")]
    public PostBase Post { get; set; }
    public string? PostId { get; set; }
    
    public RatingType Type { get; set; }
    
    public DateTime CreatedAt { get; set; }
}