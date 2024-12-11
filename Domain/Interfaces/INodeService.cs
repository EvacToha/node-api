using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.Interfaces;

public interface INodeService
{
    Task<IEnumerable<NodeDto>> GetNodesAsync();
}