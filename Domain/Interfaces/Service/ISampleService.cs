using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Responses;

namespace NodeApl.API.Domain.Interfaces;

public interface ISampleService
{
    Task<IEnumerable<SampleDto>> GetByNodeIdAsync(int nodeId);
    Task<IEnumerable<SampleDto>> GetByNodeIdsAsync(IEnumerable<int> nodeIds);

    Task<SampleAddResponse> AddByLoginAsync(string login, SampleAddDto sampleAddDto);

    Task<SampleDeleteResponse> DeleteByIdsAsync(IEnumerable<int> ids);
    
    Task<SampleUpdateResponse> Update(string login, SampleUpdateDto sample);
}