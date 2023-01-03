using AspektJob.DTOs.ModelDTOs;
using AspektJob.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspektJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
       private ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpPost("add")]
        public ActionResult AddCountry(CountryDto country)
        {
            _countryService.CreateCountry(country);
            return StatusCode(StatusCodes.Status201Created, "You added a country!!!");
        }
        [HttpGet("getAll")]
        public ActionResult<List<CountryDto>> GetAll()
        {
            return _countryService.GetAll();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCountry(int id)
        {
            _countryService.DeleteCountry(id);
            return StatusCode(StatusCodes.Status200OK, "Country deleted!!!");
        }

        [HttpPost("update")]
        public ActionResult UpdateCountry(CountryDto country)
        {
            _countryService.UpdateCountry(country);
            return StatusCode(StatusCodes.Status200OK, $"Country with id: {country.Id} updated!!!");
        }


    }
}
