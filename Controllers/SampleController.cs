using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;
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
    /// <response code="400">Ошибка API</response>
    
    [HttpGet("{nodeId?}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSamplesByNodeId([FromRoute] int nodeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var samples = await sampleService.GetByNodeIdAsync(nodeId);
        
        return Ok(samples);
    }
    
    /// <summary>
    /// Получить выборки по нескольким id
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    
    [HttpPost("by-node-ids")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSamplesByNodeIds([FromBody] IEnumerable<int> nodeIds)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var samples = await sampleService.GetByNodeIdsAsync(nodeIds);
        
        return Ok(samples);
    }

    /// <summary>
    /// Добавить элемент выборки
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Sample/add-sample
    ///     {
    ///        "name": "Описание Шаблона 1", 
    ///        "createDate": "2024-12-26",
    ///        "nodeId": 0
    ///     }
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="201">Успешное создание</response>
    /// <response code="400">Ошибка API</response>

    [HttpPost("add-sample")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SampleDto>> AddSampleByLogin([FromQuery] string login, [FromBody] SampleAddDto sample)
    {
        var result = await sampleService.AddByLoginAsync(login, sample);
        if (!result.Success)
        {
            return BadRequest(new {
                result.Message
            });
        }
        
        return CreatedAtAction(nameof(AddSampleByLogin), new {id = result.SampleDto.Id}, result.SampleDto);
    }

    /// <summary>
    /// Удалить элементы выборки по айди
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Sample/add-sample
    ///     {
    ///        "ids": [1,2,3]
    ///     }
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное удаление</response>
    /// <response code="400">Ошибка API</response>
    
    [HttpPost("delete-samples")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteSamplesByIds([FromBody] IEnumerable<int> ids)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await sampleService.DeleteByIdsAsync(ids);

        if (!result.Success)
        {
            return BadRequest(new
            {
                result.Message
            });
        }
        
        return Ok(new {
            result.DeletedIds, 
            result.FailedIds
        });
    }
    
    /// <summary>
    /// Обновить элемент выборки
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /api/Sample/update-sample
    ///     {
    ///        "id": 4,
    ///        "name": "Описание Шаблона 1",
    ///        "createDate": "2024-12-26"
    ///     }
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное обновление</response>
    /// <response code="400">Ошибка API</response>
    
    [HttpPut("update-sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSample([FromQuery] string login, [FromBody] SampleUpdateDto sample)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await sampleService.Update(login, sample);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        
        return Ok();
    }
}