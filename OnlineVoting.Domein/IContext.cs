using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Domein
{
    public interface IContext
    {
       public DbSet<User> users { get; set; }
       public int saveChanges();

    }
}
