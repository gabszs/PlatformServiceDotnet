using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly IHttpComandDataClient _httpComandDataClient;

        public PlatformsController(IPlatformRepo repository, IMapper mapper, IHttpComandDataClient httpComandDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _httpComandDataClient = httpComandDataClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatforms()
        {
            System.Console.WriteLine("--> Geting Platforms........");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var platformItem = await _repository.GetAllPlatforms();
            if (platformItem != null)
            {
                IEnumerable<PlatformReadDto> platformsDto = _mapper.Map<IEnumerable<PlatformReadDto>>(platformItem);
                
                return Ok(platformsDto);
            }

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(int id)
        {
            System.Console.WriteLine($"--> Geting {id} platform.........");
            var platform = await _repository.GetPlatformById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (platform != null)
            {
                PlatformReadDto platformDto = _mapper.Map<PlatformReadDto>(platform);
                return Ok(platformDto);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            bool isPlatformNull = platformCreateDto == null;
            bool isModelStateInvalid = !ModelState.IsValid;  
            if (isPlatformNull || isModelStateInvalid)
            {
                return BadRequest(ModelState);
            }

            var platformModel = _mapper.Map<Platform>(platformCreateDto);            
            _repository.CreatePlatform(platformModel);

            if (!await _repository.SaveChanges())
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            try
            {
                await _httpComandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"---->>>> FAILED, Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById), new { id = platformReadDto.Id}, platformReadDto);
        }
    }
}