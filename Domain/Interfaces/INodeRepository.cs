using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.Interfaces;

public interface INodeRepository
{
    Task<IEnumerable<Node>> GetNodesAsync();
}