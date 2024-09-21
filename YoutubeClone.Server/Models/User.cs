using Microsoft.AspNetCore.Identity;

namespace YoutubeClone.Server.Models;

public class User : IdentityUser<Guid>
{
    public ICollection<VideoPost> VideoPosts { get; set; } = null!;
    public ICollection<CommunityPost> CommunityPosts { get; set; } = null!;
}