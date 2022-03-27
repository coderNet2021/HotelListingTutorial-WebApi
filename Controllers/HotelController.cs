using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HotelController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork,ILogger<CountryController> logger,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _logger=logger;
            _mapper=mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]//for the swagger documentation
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                //use newtonSoft.json that is optimized for asp.NET core
                //and register it as a service in startup
                var hotels = await _unitOfWork.Hotels.GetAll();
                var results= _mapper.Map<IList<HotelDTO>>(hotels); 
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,$"Something Went Wrong in {nameof(GetHotels)}");
                return StatusCode(500,"Internal Server Error plz try again later . ");
            }
        }

         [HttpGet("{id:int}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                //use newtonSoft.json that is optimized for asp.NET core
                //and register it as a service in startup
                var hotel = await _unitOfWork.Hotels.Get(q =>q.Id==id);
                var result= _mapper.Map<HotelDTO>(hotel); 
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,$"Something Went Wrong in {nameof(GetHotel)}");
                return StatusCode(500,"Internal Server Error plz try again later . ");
            }
        }


    }
}