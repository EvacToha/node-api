using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Controllers.Constants;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Interfaces;
using NodeApl.API.Services;

namespace NodeApl.API.Controllers;

[Authorize]
public class NodeController(INodeService nodeService) : BaseController
{
    
    [HttpGet(RouteNames.Nodes)]
    public async Task<IActionResult> GetNodes()
    {
        var nodes = await nodeService.GetNodesAsync();
        
        return Ok(nodes);
    }
}   