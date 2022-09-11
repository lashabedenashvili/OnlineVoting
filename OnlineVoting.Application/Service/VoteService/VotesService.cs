using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Api.Models;
using OnlineVoting.Api.Models.User;
using OnlineVoting.Data;
using OnlineVoting.Domein;
using OnlineVoting.Infrastructure.Dto.UserServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Service.VoteService
{
    public class VotesService : IVotesService
    {

        private readonly IContext _context;
       

        public VotesService(IContext context,IMapper mapper)
        {

            _context = context;
          
        }
        public async Task<ServiceResponce<string>> AddVote(string personalNumber, string number)
        {

            var response = new ServiceResponce<string>();
           
            var userId = await GetUserIdByPersonalNumber(personalNumber);
            if (!UniqueVote(userId.Data).Success)
            {
                response.Success = false;
                response.Message = "Your vote has already been recorded";
                return response;
            }
            var candidateId = await GetCandidateIdByNumber(number);

            if (userId.Data.Equals(0) || candidateId.Data.Equals(0))
            {
                response.Success = false;
                response.Message = "User number or candidate number is not correct.";
                return response;
            }
            else
            {
                var newVote = new Votes
                {
                    Vote = 1,
                    Time = DateTime.Now,
                    CandidateId =  candidateId.Data,
                    UserId=userId.Data,

                };
                _context.votes.Add(newVote);
                _context.saveChanges();
                response.Success = true;
                response.Message = "you vote is reflected.";
                return response;
            }
            
            

        }
        private ServiceResponce<bool>UniqueVote(int userId)
        {
            var response=new ServiceResponce<bool>();
           var userVoteUniuqe=_context.votes.AnyAsync(x=>x.Id==userId);
            if (userVoteUniuqe != null)
            {
                response.Success = false;
                
                return response;
            }
            else response.Success = true;
            return response;
        }
        private async Task<ServiceResponce<int>> GetUserIdByPersonalNumber(string personalNumber)
        {
            var response = new ServiceResponce<int>();
            var userId = await _context.users
                .Where(x => x.PersonalNumber == personalNumber)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if (userId == 0)
            {
                response.Success = false;
                response.Message = "User does not exist.";
            }
            else response.Data = userId;
            return response;
        }
        private async Task<ServiceResponce<int>> GetCandidateIdByNumber(string number)
        {
            var response = new ServiceResponce<int>();
            var candidateId = await _context.candidates
                .Where(x => x.Number == number)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
            if (candidateId == 0)
            {
                response.Success = false;
                response.Message = "Candidate does not exist.";
            }
            else response.Data = candidateId;
            return response;
        }

        public async Task<ServiceResponce<int>> GetAllVote(string candidateNumber)
        {
            var response=new ServiceResponce<int>();
            var candidateId = await GetCandidateIdByNumber(candidateNumber);
            if (candidateId.Success==false)
            {                 
                response.Success = false;
                response.Message = candidateId.Message;
                return response;
            }
            var votes = _context.votes.Where(x => x.CandidateId == candidateId.Data).SumAsync(x => x.Vote);
           
            response.Data =await votes;

            return response;
        }
    }
}
