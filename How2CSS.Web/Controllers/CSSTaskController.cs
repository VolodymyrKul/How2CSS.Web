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
    [Route("api/csstasks")]
    public class CSSTaskController : ControllerBase
    {
        private ICSSTaskService _cSSTaskService;

        public CSSTaskController(ICSSTaskService cSSTaskService)
        {
            _cSSTaskService = cSSTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CSSTaskDTO>>> Get()
        {

            var result = await _cSSTaskService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CSSTaskDTO>> getById(int id)
        {
            var result = await _cSSTaskService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CSSTaskDTO>> Pull(CSSTaskDTO order)
        {
            await _cSSTaskService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<CSSTaskDTO>> Update(CSSTaskDTO order)
        {
            var result = await _cSSTaskService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cSSTaskService.DeleteAsync(id);
            return NoContent();
        }
    }
}
