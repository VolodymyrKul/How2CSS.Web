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
    [Route("api/unitdistribs")]
    public class UnitDistributionController : ControllerBase
    {
        private IUnitDistributionService _unitDistributionService;

        public UnitDistributionController(IUnitDistributionService unitDistributionService)
        {
            _unitDistributionService = unitDistributionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UnitDistributionDTO>>> Get()
        {

            var result = await _unitDistributionService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDistributionDTO>> getById(int id)
        {
            var result = await _unitDistributionService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UnitDistributionDTO>> Pull(UnitDistributionDTO order)
        {
            await _unitDistributionService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<UnitDistributionDTO>> Update(UnitDistributionDTO order)
        {
            var result = await _unitDistributionService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitDistributionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
