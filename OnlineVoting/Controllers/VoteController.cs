using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Api.Models;
using OnlineVoting.Application.Service.VoteService;
using OnlineVoting.Data;
using OnlineVoting.Infrastructure.Dto.UserServiceDto;

namespace OnlineVoting.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVotesService _voteService;

        public VoteController(IVotesService voteService)
        {
            _voteService = voteService;
        }
        [HttpPost("AddVote")]
        public async Task <ActionResult<ServiceResponce<string>>>AddVotes(AddVoteDto voter)
        {
            return Ok(await _voteService.AddVote(voter.PersonalNumber,voter.Number));
        }

        [HttpGet("GetAllVotes")]
        public async Task<ActionResult<ServiceResponce<int>>>GetAllVotes(string candidateNumber)
        {
            return Ok(await _voteService.GetAllVote(candidateNumber));
        }
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<ServiceResponce<int>>> GetAllUser()
        {
            return Ok(await _voteService.GetAllVoterSum());
        }
    }
}
