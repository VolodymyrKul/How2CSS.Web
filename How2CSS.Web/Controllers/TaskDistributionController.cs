using How2CSS.Core.Abstractions.IServices;
using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace How2CSS.Web.Controllers
{
    [ApiController]
    [Route("api/taskdistribs")]
    public class TaskDistributionController : ControllerBase
    {
        private ITaskDistributionService _taskDistributionService;

        public TaskDistributionController(ITaskDistributionService taskDistributionService)
        {
            _taskDistributionService = taskDistributionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDistributionDTO>>> Get()
        {

            var result = await _taskDistributionService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDistributionDTO>> getById(int id)
        {
            var result = await _taskDistributionService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDistributionDTO>> Pull(TaskDistributionDTO order)
        {
            await _taskDistributionService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<TaskDistributionDTO>> Update(TaskDistributionDTO order)
        {
            var result = await _taskDistributionService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskDistributionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
