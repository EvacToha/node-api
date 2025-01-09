namespace NodeApl.API.Domain.DTOs;

public class NodeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    
    public List<NodeDto> Children { get; set; } = [];
}