using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Api.Models;
using OnlineVoting.Api.Models.User;
using OnlineVoting.Domein;
using OnlineVoting.Data;
using OnlineVoting.Infrastructure.Dto;
using AutoMapper;
using OnlineVoting.Infrastructure.Dto.UserServiceDto;

namespace OnlineVoting.Api.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserAutentication _userAuthentication;

        private readonly IMapper _mapper;

        public UserAuthenticationController(IUserAutentication userAuthentication,IMapper mapper)
        {
            _userAuthentication = userAuthentication;     
            _mapper = mapper;
        }



        [HttpPost("Registration")]
        public async Task<ActionResult<ServiceResponce<int>>> Registration(UserRegistrationDto request)
        {
            var _user = _mapper.Map<User>(request);
            var registration= await _userAuthentication.Registration(_user, request.Password);

            if (!registration.Success)
            {
                return BadRequest(registration);
            }
            return Ok(registration);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponce<string>>>Login(UserLoginDto request)
        {

            var login= await _userAuthentication.Login(request);
            if (!login.Success)
            {
                return BadRequest(login);
            }
            return Ok(login);
        }
        [HttpPost("Password Update")]
        public async Task<ActionResult<ServiceResponce<string>>>UpdatePassword(UserUpdatePasswordDto request)
        {
            var updatePassword= await _userAuthentication.UpdateUserPassword(request);
            if (!updatePassword.Success)
            {
                return BadRequest(updatePassword);
            }
            return Ok(updatePassword);
        }

    }

}
