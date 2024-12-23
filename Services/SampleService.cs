using NodeApl.API.Domain.DTOs;

using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Services;

public class SampleService(ISampleRepository sampleRepository) : ISampleService
{
    public async Task<IEnumerable<SampleDto>> GetSamplesByNodeIdAsync(int nodeId)
    {
        return await sampleRepository.GetSamplesByNodeIdAsync(nodeId);
    }

    public async Task<IEnumerable<SampleDto>> GetSamplesByNodeIdsAsync(IEnumerable<int> nodeIds)
    {
        return await sampleRepository.GetSamplesByNodeIdsAsync(nodeIds);
    }
}