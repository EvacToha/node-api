using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.Interfaces;

public interface ISampleRepository : IRepository<Sample>
{
    Task<IEnumerable<SampleDto>> GetSamplesByNodeIdAsync(int nodeId);
    Task<IEnumerable<SampleDto>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds);
}