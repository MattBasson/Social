using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Social.Database.Domain.Comments;

namespace Social.Database.Infrastructure.EntityFramework
{
    
    public class SocialContext : DbContext
    {


        public SocialContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        
    }
}
