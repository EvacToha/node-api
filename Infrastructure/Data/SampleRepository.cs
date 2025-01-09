using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Infrastructure.Data;

public class SampleRepository(AppDbContext dbContext, IMapper mapper) : Repository<Sample>(dbContext), ISampleRepository
{
    public async Task<IEnumerable<SampleDto>> GetSamplesByNodeIdAsync(int nodeId)
    {
        
        return await dbContext.Samples
            .Include(s => s.User)
            .Where(s => s.NodeId == nodeId)
            .ProjectTo<SampleDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<SampleDto>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds)
    {
        return await dbContext.Samples
            .Include(s => s.User)
            .Where(s => nodeIds.Contains(s.NodeId))
            .ProjectTo<SampleDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<Sample>> GetSamplesByIdsAsync(IEnumerable<int> ids)
    {
        return await dbContext.Samples.Where(s => ids.Contains(s.Id)).ToListAsync();
    }
}