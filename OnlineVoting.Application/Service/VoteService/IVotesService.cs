using OnlineVoting.Api.Models;
using OnlineVoting.Infrastructure.Dto.UserServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Service.VoteService
{
    public interface IVotesService
    {
        Task<ServiceResponce<string>>AddVote(string personalNumber, string number);
    }
}
