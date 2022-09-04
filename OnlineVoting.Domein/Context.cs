using Microsoft.EntityFrameworkCore;
using OnlineVoting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Domein
{
    public class Context:DbContext,IContext
    {
        public DbSet<User> users { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        

        public int saveChanges()
        {
           return SaveChanges();
        }
    }
}
