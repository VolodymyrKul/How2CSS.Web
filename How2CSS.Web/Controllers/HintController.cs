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
    [Route("api/hints")]
    public class HintController : ControllerBase
    {
        private IHintService _hintService;

        public HintController(IHintService hintService)
        {
            _hintService = hintService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HintDTO>>> Get()
        {

            var result = await _hintService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HintDTO>> getById(int id)
        {
            var result = await _hintService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HintDTO>> Pull(HintDTO order)
        {
            await _hintService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<HintDTO>> Update(HintDTO order)
        {
            var result = await _hintService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _hintService.DeleteAsync(id);
            return NoContent();
        }
    }
}
