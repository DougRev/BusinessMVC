using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessMVC2.Models
{
    public class TokenDbContext : DbContext
    {
        public TokenDbContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Token> Tokens { get; set; }
    }

}