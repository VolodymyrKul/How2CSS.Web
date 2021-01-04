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
    [Route("api/taskresults")]
    public class TaskResultController : ControllerBase
    {
        private ITaskResultService _taskResultService;

        public TaskResultController(ITaskResultService taskResultService)
        {
            _taskResultService = taskResultService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskResultDTO>>> Get()
        {

            var result = await _taskResultService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResultDTO>> getById(int id)
        {
            var result = await _taskResultService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResultDTO>> Pull(TaskResultDTO order)
        {
            await _taskResultService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<TaskResultDTO>> Update(TaskResultDTO order)
        {
            var result = await _taskResultService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskResultService.DeleteAsync(id);
            return NoContent();
        }
    }
}
