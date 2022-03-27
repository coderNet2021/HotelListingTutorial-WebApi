
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CountryController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitoOfWork , ILogger<CountryController> logger,IMapper mapper)
        {
            _unitOfWork=unitoOfWork;
            _logger=logger;
            _mapper=mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                //use newtonSoft.json that is optimized for asp.NET core
                //and register it as a service in startup
                var countries = await _unitOfWork.Countries.GetAll();
                var results= _mapper.Map<IList<CountryDTO>>(countries); 
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,$"Something Went Wrong in {nameof(GetCountries)}");
                return StatusCode(500,"Internal Server Error plz try again later . ");
            }
        }

         [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                //use newtonSoft.json that is optimized for asp.NET core
                //and register it as a service in startup
                var countries = await _unitOfWork.Countries.Get(q =>q.Id==id);
                var result= _mapper.Map<CountryDTO>(countries); 
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,$"Something Went Wrong in {nameof(GetCountries)}");
                return StatusCode(500,"Internal Server Error plz try again later . ");
            }
        }
    }
}