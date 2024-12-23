using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;


namespace NodeApl.API.Services;

public class NodeService(IRepository<Node> nodeRepository) : INodeService
{
    
    private static List<NodeDto> ConvertToDto(IEnumerable<Node> nodes)
    {
        return nodes.Select(node => new NodeDto
        {
            Name = node.Name,
            Type = node.Type,
            Children = ConvertToDto(node.Children) 
        }).ToList();
    }
    
    public async Task<IEnumerable<NodeDto>> GetNodesAsync()
    {
        var nodes = await nodeRepository.GetAllAsync();

        var nodesDto = ConvertToDto(nodes.Where(node => node.ParentId == null));
        
        return await Task.FromResult(nodesDto);
    }
}