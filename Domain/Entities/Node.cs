using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.Entities;

public class Node
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = "";
    [Required]
    [MaxLength(20)]
    public string Type { get; set; } = "";
    public int? ParentId { get; set; }
    [Required]
    public List<Node> Children { get; set; } = [];
}