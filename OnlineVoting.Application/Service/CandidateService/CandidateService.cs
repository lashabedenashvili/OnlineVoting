using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Api.Models;
using OnlineVoting.Data;
using OnlineVoting.Domein;
using OnlineVoting.Infrastructure.Dto.CandidateServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Service.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CandidateService(IContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponce<List<GetCandidateDto>>> AddCandidate(Candidate newCandidate)
        {
            var response = new ServiceResponce<List<GetCandidateDto>>();
            
            if ( await CandidateExist(newCandidate.PersonalNumber))
            {
                response.Success = false;
                response.Message = "Candidate already exist.";
            }
            else
            {
                await _context.candidates.AddAsync(newCandidate);
                _context.saveChanges();
                response.Success = true;
            }
            return response;
        }

        public async Task<bool> CandidateExist(string personalNumber)
        {
          return await _context.candidates.AnyAsync(x=>x.PersonalNumber.Equals(personalNumber));
        }

        public async Task<ServiceResponce<string>> DeleteCandidateById(int id)
        {
            var response = new ServiceResponce<string>();
            var deleteCandidate=await _context.candidates.FirstAsync(x=>x.Id==id);
            if (deleteCandidate == null)
            {
                response.Success=false;
                response.Message = "Candidate does not exist.";
            }
            else
            {                
                _context.candidates.Remove(deleteCandidate);
                _context.saveChanges();
                response.Success = true;
            }               

            return response;
        }

        public async Task<ServiceResponce<List<GetCandidateDto>>> GetAllCandidate()
        {
            var response=new ServiceResponce<List<GetCandidateDto>>();
            var candidates= await _context.candidates.ToListAsync();
            response.Data = _mapper.Map<List<GetCandidateDto>>(candidates);
            return response;
        }

        public async Task<ServiceResponce<GetCandidateDto>> GetCandidateById(int id)
        {
            var response = new ServiceResponce<GetCandidateDto>();

            var candidate = await _context.candidates.FirstOrDefaultAsync(p => p.Id == id);
            if(candidate == null)
            {
                response.Success = false;
                response.Message = "Candidate does not exist.";
            }
            else
            {
                response.Data = _mapper.Map<GetCandidateDto>(candidate); 
            }
            return response;
        }

        public async Task<ServiceResponce<GetCandidateDto>> UpdateCandidate(UpdateCandidateDto updateCandidate)
        {
            var response=new ServiceResponce<GetCandidateDto>();
         
            var candidate = await _context.candidates
                .FirstOrDefaultAsync(x => x.PersonalNumber == updateCandidate.PersonalNumber);
            if(candidate == null)
            {

                response.Success = false;
                response.Message = "Candidate does not exist.";
            }
            else
            {
                var _candidate = _mapper.Map<UpdateCandidateDto,Candidate>(updateCandidate,candidate);

                var updateCandidates = _context.candidates.Update(_candidate);

                _context.candidates.Update(_candidate);
                _context.saveChanges(); 
                response.Data=_mapper.Map<GetCandidateDto>(_candidate);
            }
            return response;
        }
    }
}
