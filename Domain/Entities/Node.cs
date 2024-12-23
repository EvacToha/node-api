using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.Entities;

/// <summary>
/// Узел
/// </summary>
public class Node
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Имя узла
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = "";
    /// <summary>
    /// Тип
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Type { get; set; } = "";
    /// <summary>
    /// Ид корневого узла
    /// </summary>
    public int? ParentId { get; set; }
    /// <summary>
    /// Дочерние узлы
    /// </summary>
    [Required]
    public List<Node> Children { get; set; } = [];
    /// <summary>
    /// Выборка
    /// </summary>
    
    public List<Sample> Samples { get; set; } = [];
}