using System;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.API.Commons;

public interface IBaseController<Tdto>
{
    Task<ActionResult<IEnumerable<Tdto>>> GetAll();
    Task<ActionResult<Tdto>> GetOne(Guid id);
    Task<ActionResult<Tdto>> Create(Tdto itemDTO);
    Task<IActionResult> Update(Guid id, Tdto itemDTO);
    Task<IActionResult> Delete(Guid id);
}
