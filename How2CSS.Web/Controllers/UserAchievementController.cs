using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace How2CSS.Web.Controllers
{
    [ApiController]
    [Route("api/userachievs")]
    public class UserAchievementController : ControllerBase
    {
        private IUserAchievementService _userAchievementService;

        public UserAchievementController(IUserAchievementService userAchievementService)
        {
            _userAchievementService = userAchievementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserAchievementDTO>>> Get()
        {

            var result = await _userAchievementService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAchievementDTO>> getById(int id)
        {
            var result = await _userAchievementService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserAchievementDTO>> Pull(UserAchievementDTO order)
        {
            await _userAchievementService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<UserAchievementDTO>> Update(UserAchievementDTO order)
        {
            var result = await _userAchievementService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userAchievementService.DeleteAsync(id);
            return NoContent();
        }
    }
}
