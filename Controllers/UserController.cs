using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.DTO;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users); // Retourne les utilisateurs en réponse HTTP 200
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetOne(long id)
        {
            try
            {
                var user = await _userService.GetOne(id);
                return Ok(user); // Retourne un utilisateur en réponse HTTP 200
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Si l'utilisateur n'est pas trouvé, réponse HTTP 404
            }
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserDto userDto)
        {
            var createdUser = await _userService.Post(userDto);
            return CreatedAtAction(nameof(GetOne), new { id = createdUser.Id }, createdUser); // Retourne HTTP 201 avec l'URL de l'objet créé
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(long id, UserDto userDto)
        {
            try
            {
                var updatedUser = await _userService.Update(id, userDto);
                return Ok(updatedUser); // Retourne l'utilisateur mis à jour en réponse HTTP 200
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Si l'utilisateur n'est pas trouvé, réponse HTTP 404
            }
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var success = await _userService.Delete(id);
            if (success)
            {
                return NoContent(); // Si la suppression est réussie, retourne HTTP 204 (sans contenu)
            }
            else
            {
                return NotFound(); // Si l'utilisateur n'existe pas, retourne HTTP 404
            }
        }
    }
}
