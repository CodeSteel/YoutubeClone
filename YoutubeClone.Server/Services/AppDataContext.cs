using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YoutubeClone.Server.Models;

namespace YoutubeClone.Server.Data;

public class AppDataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    private readonly IConfiguration _configuration;
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<FileUpload> FileUploads { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    
    public DbSet<VideoPost> VideoPosts { get; set; }
    public DbSet<CommunityPost> CommunityPosts { get; set; }
    
    public AppDataContext(DbContextOptions<AppDataContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("default"));
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PostBase>(ent =>
        {
            ent.ToTable("Posts");
            ent.HasDiscriminator<PostType>("Type")
                .HasValue<VideoPost>(PostType.Video)
                .HasValue<CommunityPost>(PostType.Community);
            ent.HasMany(p => p.Ratings)
                .WithOne(r => r.Post)
                .HasForeignKey(r => r.PostId);
        });
        builder.Entity<VideoPost>(ent =>
        {
            ent.HasOne(p => p.Owner)
                .WithMany(u => u.VideoPosts)
                .HasForeignKey(p => p.OwnerId);
        });
        builder.Entity<CommunityPost>(ent =>
        {
            ent.HasOne(p => p.Owner)
                .WithMany(u => u.CommunityPosts)
                .HasForeignKey(p => p.OwnerId);
        });
        base.OnModelCreating(builder);
    }
}