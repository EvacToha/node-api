using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Domain.Interfaces;


namespace NodeApl.API.Controllers;


[Authorize]
public class NodeController(INodeService nodeService) : BaseController
{
    /// <summary>
    /// Получить все узлы
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("/api/Nodes")]
    public async Task<IActionResult> GetNodes()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var nodes = await nodeService.GetNodesAsync();
        
        return Ok(nodes);
    }
}   