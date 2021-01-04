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
    [Route("api/metadatas")]
    public class MetadataController : ControllerBase
    {
        private IMetadataService _metadataService;

        public MetadataController(IMetadataService metadataService)
        {
            _metadataService = metadataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MetadataDTO>>> Get()
        {

            var result = await _metadataService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetadataDTO>> getById(int id)
        {
            var result = await _metadataService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MetadataDTO>> Pull(MetadataDTO order)
        {
            await _metadataService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<MetadataDTO>> Update(MetadataDTO order)
        {
            var result = await _metadataService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _metadataService.DeleteAsync(id);
            return NoContent();
        }
    }
}
