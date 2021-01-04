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
    [Route("api/tagdistribs")]
    public class TagDistributionController : ControllerBase
    {
        private ITagDistributionService _tagDistributionService;

        public TagDistributionController(ITagDistributionService tagDistributionService)
        {
            _tagDistributionService = tagDistributionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDistributionDTO>>> Get()
        {

            var result = await _tagDistributionService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDistributionDTO>> getById(int id)
        {
            var result = await _tagDistributionService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TagDistributionDTO>> Pull(TagDistributionDTO order)
        {
            await _tagDistributionService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<TagDistributionDTO>> Update(TagDistributionDTO order)
        {
            var result = await _tagDistributionService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagDistributionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
