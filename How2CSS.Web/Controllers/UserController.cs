using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace How2CSS.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {

            var result = await _userService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> getById(int id)
        {
            var result = await _userService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Pull(SignUpDTO order)
        {
            List<UserDTO> users = await _userService.GetAll();
            var result = users.FirstOrDefault(u => u.Email == order.Email);
            if (result == null)
            {
                await _userService.CreateAsync(order);
                return Ok(order);
            }
            else
            {
                return BadRequest("User already is in database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(UserDTO order)
        {
            var result = await _userService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
