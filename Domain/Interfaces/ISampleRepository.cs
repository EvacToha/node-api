using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.Interfaces;

public interface ISampleRepository
{
    Task<IEnumerable<Sample>> GetSamplesByNodeIdAsync(int nodeId);
    Task<IEnumerable<Sample>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds);
}