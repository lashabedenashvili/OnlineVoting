using OnlineVoting.Api.Models;
using OnlineVoting.Data;
using OnlineVoting.Infrastructure.Dto.CandidateServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Service.CandidateService
{
    public interface ICandidateService
    {
        Task<ServiceResponce<List<GetCandidateDto>>> AddCandidate(Candidate newCandidate);
        Task<ServiceResponce<List<GetCandidateDto>>> GetAllCandidate();
        Task<ServiceResponce<GetCandidateDto>> GetCandidateById(int id);
        Task<ServiceResponce<string>> DeleteCandidateById(int id);
        Task<ServiceResponce<GetCandidateDto>>UpdateCandidate(UpdateCandidateDto updateCandidate);
        Task<bool> CandidateExist(string personalNumber);
    }
}
