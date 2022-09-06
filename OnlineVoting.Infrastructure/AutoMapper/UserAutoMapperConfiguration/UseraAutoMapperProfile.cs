using AutoMapper;
using OnlineVoting.Data;
using OnlineVoting.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.AutoMapper.UserAutoMapperConfiguration
{
    public class UseraAutoMapperProfile : Profile
    {
        public UseraAutoMapperProfile()
        {
            CreateMap<UserRegistrationDto, User>()
                .ForMember(x => x.PasswordHash, c => c.Ignore())
                .ForMember(x => x.PasswordSalt, c => c.Ignore())
                .ForMember(x => x.Id, c => c.Ignore())
                .ForSourceMember(x => x.Password, c => c.DoNotValidate());
        }
    }
}
