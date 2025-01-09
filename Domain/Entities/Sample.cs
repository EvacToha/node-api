using System.ComponentModel.DataAnnotations;
using System.Text.Json; 
using System.Text.Json.Serialization;

namespace NodeApl.API.Domain.Entities;

public class Sample
{
    [Key]
    public int Id { get; set; }
    [Required] [MaxLength(20)] 
    public string Name { get; set; } = "";
    [Required]
    public DateTime CreateDate { get; set; }
    [Required] 
    public int NodeId { get; set; }
    [Required] 
    public int UserId { get; set; }
    public User User { get; set; }
    
}
