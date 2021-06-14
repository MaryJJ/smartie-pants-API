using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartiePants.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartiePants.Data
{
    public class SPDbContext : IdentityDbContext<User, Role, Guid>
    {
        public SPDbContext(DbContextOptions<SPDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}