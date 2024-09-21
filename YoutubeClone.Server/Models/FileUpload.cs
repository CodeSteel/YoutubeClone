using System.ComponentModel.DataAnnotations;

namespace YoutubeClone.Server.Models;

public class FileUpload
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public string FilePath { get; set; }
}