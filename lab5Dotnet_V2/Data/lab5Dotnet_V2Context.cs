using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab5Dotnet_V2.Models;

namespace lab5Dotnet_V2.Data
{
    public class lab5Dotnet_V2Context : DbContext
    {
        public lab5Dotnet_V2Context (DbContextOptions<lab5Dotnet_V2Context> options)
            : base(options)
        {
        }

        public DbSet<lab5Dotnet_V2.Models.Books> Books { get; set; } = default!;
    }
}
