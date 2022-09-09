using AutoMapper;
using OnlineVoting.Data;
using OnlineVoting.Infrastructure.Dto.CandidateServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.AutoMapper.CandidateProfile
{
    public class CandidateAutoMapperProfile : Profile
    {
        public CandidateAutoMapperProfile()
        {
            CreateMap<AddCandidateDto, Candidate>()
                           .ForMember(x => x.Id, c => c.Ignore());

            CreateMap<Candidate, GetCandidateDto>();
            CreateMap<UpdateCandidateDto, Candidate>()
                .ForAllMembers(c => c.Condition((src, dest, srcMember) => srcMember != null)); 
        }
    }
}
