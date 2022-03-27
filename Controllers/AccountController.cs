using AutoMapper;
using HotelListing.Data;
using HotelListing.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager,SignInManager<ApiUser> signInManager,ILogger<CountryController> logger,IMapper mapper)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _logger=logger;
            _mapper=mapper;
        }
    }
}