using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Services;

public class SampleService(ISampleRepository sampleRepository) : ISampleService
{
    public async Task<IEnumerable<Sample>> GetSamplesByNodeIdAsync(int nodeId)
    {
        return await sampleRepository.GetSamplesByNodeIdAsync(nodeId);
    }

    public async Task<IEnumerable<Sample>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds)
    {
        return await sampleRepository.GetSamplesByNodeIdsAsync(nodeIds);
    }
}