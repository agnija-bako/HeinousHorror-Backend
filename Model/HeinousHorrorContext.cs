using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace heinousHorror.Model
{   
    public class HeinousHorrorContext : DbContext
    {
        public HeinousHorrorContext(DbContextOptions<HeinousHorrorContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
