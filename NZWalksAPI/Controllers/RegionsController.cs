﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();

            var regionsDto = _mapper.Map<List<RegionDto>>(regionsDomain);
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetByID(Guid id) 
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if(regionDomain == null) 
            {
                return NotFound("Region not found");
            }

            var regionDto = _mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create(AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid) 
            {
                var regionDomain = _mapper.Map<Region>(addRegionRequestDto);
                regionDomain = await _regionRepository.CreateAsync(regionDomain);

                var regionDto = _mapper.Map<RegionDto>(regionDomain);
                return CreatedAtAction(nameof(GetByID), new { id = regionDto.Id }, regionDto);
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update(Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                var regionDomain = _mapper.Map<Region>(updateRegionRequestDto);
                regionDomain = await _regionRepository.UpdateAsync(id, regionDomain);

                var regionDto = _mapper.Map<RegionDto>(regionDomain);
                return Ok(regionDto);
            }
            else
            { 
                return BadRequest(ModelState); 
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete(Guid id)
        {
           var regionDomain = await _regionRepository.DeleteAsync(id);
           if(regionDomain == null)
           {
                return NotFound();
           }

            return Ok("Delete Successful !");

        }
    }
}
