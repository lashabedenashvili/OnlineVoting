using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Api.Models;
using OnlineVoting.Api.Models.User;
using OnlineVoting.Domein;
using OnlineVoting.Data;
using OnlineVoting.Infrastructure.Dto;
using AutoMapper;

namespace OnlineVoting.Api.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserAutentication _userAuthentication;
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public UserAuthenticationController(IUserAutentication userAuthentication, IContext context,IMapper mapper)
        {
            _userAuthentication = userAuthentication;
            _context = context;
            _mapper = mapper;
        }



        [HttpPost("Registration")]
        public async Task<ActionResult<ServiceResponce<int>>> Registration(UserRegistrationDto request)
        {
            var _user = _mapper.Map<User>(request);
            return await _userAuthentication.Registration(_user, request.Password);
        }
    }
}
