using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Controllers.Constants;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;
using NodeApl.API.Domain.Interfaces;
using NodeApl.API.Services;

namespace NodeApl.API.Controllers;


[Authorize]
public class NodeController(INodeService nodeService) : BaseController
{
    /// <summary>
    /// Получить все ноды
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet(RouteNames.Nodes)]
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