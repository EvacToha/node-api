
using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Infrastructure.Data;

public class SampleRepository(AppDbContext dbContext) : ISampleRepository
{
    public async Task<IEnumerable<Sample>> GetSamplesByNodeIdAsync(int nodeId)
    {
        return await dbContext.Samples.Where(s => s.NodeId == nodeId).ToListAsync();
    }

    public async Task<IEnumerable<Sample>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds)
    {
        return await dbContext.Samples.Where(s => nodeIds.Contains(s.NodeId)).ToListAsync();
    }
}