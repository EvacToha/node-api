using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.DTOs;

public class SampleAddDto
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public DateTime CreateDate { get; set; }
    [Required]
    public int NodeId { get; set; }
}