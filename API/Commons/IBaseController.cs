using System;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.API.Commons;

public interface IBaseController<TDto>
{
    Task<ActionResult<IEnumerable<TDto>>> GetAll();
    Task<ActionResult<TDto>> GetOne(Guid id);
    Task<ActionResult<TDto>> Create(TDto itemDTO);
    Task<IActionResult> Update(Guid id, TDto itemDTO);
    Task<IActionResult> Delete(Guid id);
}
