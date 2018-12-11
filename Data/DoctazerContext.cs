using Doctazer.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctazer.API.Data
{
    public class DoctazerContext: DbContext
    {
        public DoctazerContext(DbContextOptions<DoctazerContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
