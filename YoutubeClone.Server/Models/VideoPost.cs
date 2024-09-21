using System.ComponentModel.DataAnnotations;

namespace YoutubeClone.Server.Models;

public class VideoPost : PostBase
{
    [MaxLength(70)]
    public string Title { get; set; }
        
    public FileUpload VideoFile { get; init; }

    public override PostType Type { get; set; } = PostType.Video;
}