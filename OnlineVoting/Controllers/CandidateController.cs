using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineVoting.Api.Models;
using OnlineVoting.Application.Service.CandidateService;
using OnlineVoting.Data;
using OnlineVoting.Infrastructure.Dto.CandidateServiceDto;

namespace OnlineVoting.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICandidateService _candidateService;

        public CandidateController(IMapper mapper,ICandidateService candidateService)
        {
            _mapper = mapper;
            _candidateService = candidateService;
        }
        [HttpPost("AddCandidate")]
        public async Task<ActionResult<ServiceResponce<List<GetCandidateDto>>>>AddCandidate(AddCandidateDto newcandidate)
        {          
            var map = _mapper.Map<Candidate>(newcandidate);
            var candidate=await _candidateService.AddCandidate(map);
            if (!candidate.Success)
            {
                return BadRequest(candidate);
            }
            return Ok(candidate);
        }
        [HttpGet("GeTById")]
        public async Task<ActionResult<ServiceResponce<GetCandidateDto>>>GetCandidateById(int id)
        {
            var candidate=await _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return BadRequest(candidate);
            }
            return Ok(candidate);
        }
        [HttpPut("UpdateCandidate")]
        public async Task<ActionResult<ServiceResponce<GetCandidateDto>>> UpdateCandidate(UpdateCandidateDto updateCandidate)
        {
            var candidate = await _candidateService.UpdateCandidate(updateCandidate);
            if (candidate == null) return BadRequest(candidate);
            return Ok(candidate);       

            
        }
        [HttpGet("GetAllCandidates")]
        public async Task<ActionResult<ServiceResponce<List<GetCandidateDto>>>> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidate();
            return Ok(candidates);
        }
        [HttpDelete("DeleteCandidateById")]
        public async Task<ActionResult<ServiceResponce<string>>>DeleteCandidateById(int id)
        {
            var candidate = await _candidateService.DeleteCandidateById(id);
            if (candidate == null) return  BadRequest(candidate);
            return Ok(candidate);
        }
    }
}
