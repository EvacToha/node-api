using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Controllers.Constants;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Controllers;

public class SampleController(ISampleService sampleService) : BaseController
{
    
    [HttpGet(RouteNames.NodeId)]
    public async Task<IActionResult> GetSamplesByNodeId([FromRoute] int nodeId)
    {
        var samples = await sampleService.GetSamplesByNodeIdAsync(nodeId);
        
        return Ok(samples);
    }
    
    [HttpPost(RouteNames.NodeIds)]
    public async Task<IActionResult> GetSamplesByNodeIds([FromBody] IEnumerable<int> nodeIds)
    {
        var samples = await sampleService.GetSamplesByNodeIdsAsync(nodeIds);
        
        return Ok(samples);
    }   
}