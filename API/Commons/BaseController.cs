using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Commons;
using TodoApi.Application.Commons;
using TodoApi.API.Commons;


namespace TodoApi.Api.Commons;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TModel, TDto> : ControllerBase, IBaseController<TDto>
    where TModel : BaseModel
    where TDto : BaseDto
{
    protected readonly IBaseApiService<TModel, TDto> _service;


    protected BaseController(IBaseApiService<TModel, TDto> service)
    {
        _service = service;
    }


    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TDto>>> GetAll()
    {

        try
        {
            var items = await _service.GetAll();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = Constants.UnexpectedErrorMessage, details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TDto>> GetOne(Guid id)
    {

        try
        {
            var item = await _service.GetOne(id);
            return Ok(item);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = "Item not found", details = ex.Message });
        }
        catch (Exception e)
        {
            return StatusCode(500, new { message = Constants.UnexpectedErrorMessage, details = e.Message });
        }

    }

    [HttpPost]
    public virtual async Task<ActionResult<TDto>> Create(TDto itemDTO)
    {

        try
        {
            var createdItem = await _service.Post(itemDTO);
            return Ok(createdItem);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { message = Constants.UnexpectedErrorMessage, details = e.Message });
        }

    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Update(Guid id, TDto itemDTO)
    {

        try
        {
            var updatedItem = await _service.Update(id, itemDTO);
            return Ok(updatedItem);
        }
        catch (ArgumentException)
        {
            return BadRequest("The provided ID does not match the item ID.");
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"TodoItem with ID {id} not found.");
        }
        catch (DbUpdateConcurrencyException)
        {
            return Conflict("A concurrency conflict occurred while updating the TodoItem.");
        }
        catch (Exception e)
        {
            return StatusCode(500, new { message = Constants.UnexpectedErrorMessage, details = e.Message });
        }
    }


    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var success = await _service.Delete(id);

            if (!success)
            {
                return NotFound(new { message = $"{typeof(TModel).Name} not found" });
            }
            else
            {
                return NoContent();
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, new { message = Constants.UnexpectedErrorMessage, details = e.Message });
        }

    }

    protected static class Constants
    {
        public const string UnexpectedErrorMessage = "An unexpected error occurred.";
    }
}
