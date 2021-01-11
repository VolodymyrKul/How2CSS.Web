using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace How2CSS.Web.Controllers
{
    [ApiController]
    [Route("api/levels")]
    public class LevelController : ControllerBase
    {
        private ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LevelDTO>>> Get()
        {

            var result = await _levelService.GetAll();
            return Ok(result);

        }

        [HttpGet("detailed")]
        public async Task<ActionResult<List<LevelTasksDTO>>> GetDetailed()
        {

            var result = await _levelService.GetAllDetailed();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LevelDTO>> getById(int id)
        {
            var result = await _levelService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<LevelDTO>> Pull(LevelDTO order)
        {
            await _levelService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<LevelDTO>> Update(LevelDTO order)
        {
            var result = await _levelService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _levelService.DeleteAsync(id);
            return NoContent();
        }
    }
}
