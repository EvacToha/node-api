using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Infrastructure.Data;

public class NodeRepository(AppDbContext dbContext) : INodeRepository
{
    public async Task<IEnumerable<Node>> GetNodesAsync()
    {
        return await dbContext.Nodes.ToListAsync();
    }
}