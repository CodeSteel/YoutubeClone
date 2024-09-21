namespace YoutubeClone.Server.Models;

public class CommunityPost : PostBase
{
    public FileUpload? MediaFile { get; init; }
    
    public override PostType Type { get; set; } = PostType.Community;
}