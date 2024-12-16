using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.Interfaces;

public interface ISampleService
{
    Task<IEnumerable<Sample>> GetSamplesByNodeIdAsync(int nodeId);
    Task<IEnumerable<Sample>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds);
}