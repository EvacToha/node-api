using System.ComponentModel.DataAnnotations;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.DTOs;

public class SampleUpdateDto
{
    [Required] 
    public int Id { get; set; }
    [Required] [MaxLength(20)] 
    public string Name { get; set; } = "";
    [Required]
    public DateTime CreateDate { get; set; }
}