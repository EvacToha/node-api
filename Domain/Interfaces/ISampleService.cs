using NodeApl.API.Domain.DTOs;

namespace NodeApl.API.Domain.Interfaces;

public interface ISampleService
{
    Task<IEnumerable<SampleDto>> GetSamplesByNodeIdAsync(int nodeId);
    Task<IEnumerable<SampleDto>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds);
}