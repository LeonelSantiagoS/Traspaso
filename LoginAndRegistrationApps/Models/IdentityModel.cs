using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAndRegistrationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAndRegistrationApps.Models
{
    public class IdentityModel: DbContext
    {
        public IdentityModel(DbContextOptions<IdentityModel> options): base(options)
        {
        }
        public DbSet<Login> login { get; set; }
    }
}
