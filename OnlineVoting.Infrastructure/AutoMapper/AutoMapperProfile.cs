using AutoMapper;
using OnlineVoting.Infrastructure.AutoMapper.UserAutoMapperConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineVoting.Infrastructure.AutoMapper.CandidateProfile;

namespace OnlineVoting.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            new UseraAutoMapperProfile();
            new CandidateAutoMapperProfile();

        }
    }
}
