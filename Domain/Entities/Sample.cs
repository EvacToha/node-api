using System.ComponentModel.DataAnnotations;
using System.Text.Json; 
using System.Text.Json.Serialization;

namespace NodeApl.API.Domain.Entities;

/// <summary>
/// Элемент выборки
/// </summary>
public class Sample
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Имя элемента
    /// </summary>
    [Required] [MaxLength(20)] 
    public string Name { get; set; } = "";
    /// <summary>
    /// Дата создания
    /// </summary>
    [Required]
    public DateTime CreateDate { get; set; }
    /// <summary>
    /// Узел
    /// </summary>
    
    [Required] 
    public int NodeId { get; set; }
    
    /// <summary>
    /// Ид пользователя
    /// </summary>
    /// 
    [Required] 
    public int UserId { get; set; }
    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; }
    
}
