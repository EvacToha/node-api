using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Controllers.Constants;
using NodeApl.API.Domain.Interfaces;

namespace NodeApl.API.Controllers;

[Authorize]
public class SampleController(ISampleService sampleService) : BaseController
{
    /// <summary>
    /// Получить выборки по id
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    
    [HttpGet(RouteNames.NodeId)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSamplesByNodeId([FromRoute] int nodeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var samples = await sampleService.GetSamplesByNodeIdAsync(nodeId);
        
        return Ok(samples);
    }
    
    /// <summary>
    /// Получить выборки по нескольким id
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    
    [HttpPost(RouteNames.NodeIds)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSamplesByNodeIds([FromBody] IEnumerable<int> nodeIds)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var samples = await sampleService.GetSamplesByNodeIdsAsync(nodeIds);
        
        return Ok(samples);
    }   
}