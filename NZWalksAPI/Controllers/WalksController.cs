using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var walksDomain = await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            var walksDto = _mapper.Map<List<WalkDto>>(walksDomain);
            return Ok(walksDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomain = await _walkRepository.GetAsync(id);

            var walksDto = _mapper.Map<WalkDto>(walkDomain);
            return Ok(walksDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            if(ModelState.IsValid)
            {
                var walkDomain = _mapper.Map<Walk>(addWalkRequestDto);
                walkDomain = await _walkRepository.CreateAsync(walkDomain);

                var walkDto = _mapper.Map<WalkDto>(walkDomain);
                return CreatedAtAction(nameof(GetById), new {walkDto.Id}, walkDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                var walkDomain = _mapper.Map<Walk>(updateWalkRequestDto);
                walkDomain = await _walkRepository.UpdateAsync(id, walkDomain);
                if (walkDomain == null)
                {
                    return NotFound();
                }
                var walkDto = _mapper.Map<WalkDto>(walkDomain);
                return Ok(walkDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomain = await _walkRepository.DeleteAsync(id);
            if(walkDomain == null)
            {
                return NotFound();
            }
            return Ok("Delete Successful !");
        }

    }
}
