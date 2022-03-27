using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.ADO
{
    [ApiController]
    [Route("[controller]")]
    public class HotelCountryController :ControllerBase
    {
        HotelCountryDataAccess context= new HotelCountryDataAccess();
        [HttpGet]
        public IEnumerable<HotelCountry> Get()
        {
            return context.GetAllHotels();
        }

        [HttpGet("{id}")]
        public HotelCountry Get(int id)
        {
            return context.GetHotelCountryData(id);
        }
    }
}