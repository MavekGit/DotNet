using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab5Dotnet.Models;

namespace lab5Dotnet.Data
{
    public class lab5DotnetContext : DbContext
    {
        public lab5DotnetContext (DbContextOptions<lab5DotnetContext> options)
            : base(options)
        {
        }

        public DbSet<lab5Dotnet.Models.Library> Library { get; set; } = default!;
    }
}
