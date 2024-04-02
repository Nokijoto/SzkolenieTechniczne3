using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.Services;

namespace SzkolenieTechniczne3.Geo.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/geo")]
    public class CountryController:ControllerBase
    {

        private readonly CountryService _countryService;
        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }



        [HttpGet]
        public async Task<IEnumerable<CountryDto>> Read() => await _countryService.Get();


        [HttpGet("countries/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _countryService.GetById(id);
            if(cityDto==null)
            {
                return NotFound();
            }
            return Ok(cityDto);
        }
        [HttpPost("country")]
        public async Task<IActionResult> Create([FromBody] CountryDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operatonResult= await _countryService.Create(dto);
            return Ok(operatonResult.Result); 
        }

    }
}
