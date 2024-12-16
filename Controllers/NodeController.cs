using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Interfaces;
using NodeApl.API.Services;

namespace NodeApl.API.Controllers;

public class NodeController(INodeService nodeService) : BaseController
{

    [HttpGet]
    [Route("/api/Nodes")]
    public async Task<IActionResult> GetNodes()
    {
        var nodes = await nodeService.GetNodesAsync();
        
        return Ok(nodes);
    }
}   