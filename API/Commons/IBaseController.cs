using System;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.API.Commons;

public interface IBaseController<Tdto>
{
    Task<ActionResult<IEnumerable<Tdto>>> GetAll();
    Task<ActionResult<Tdto>> GetOne(long id);
    Task<ActionResult<Tdto>> Create(Tdto itemDTO);
    Task<IActionResult> Update(long id, Tdto itemDTO);
    Task<IActionResult> Delete(long id);
}
