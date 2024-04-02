using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.Services;

namespace SzkolenieTechniczne3.Geo.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/cities")]
    public class CityController : ControllerBase
    {

        private readonly CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }



        [HttpGet]
        public async Task<IEnumerable<CityDto>> Read() => await _cityService.Get();


        [HttpGet("cities/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _cityService.GetById(id);
            if (cityDto == null)
            {
                return NotFound();
            }
            return Ok(cityDto);
        }
        [HttpPost("city")]
        public async Task<IActionResult> Create([FromBody] CityDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operatonResult = await _cityService.Create(dto);
            return Ok(operatonResult.Result);
        }

    }
}
