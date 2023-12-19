using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabolatoriumDotNetNr5.Models;

namespace LabolatoriumDotNetNr5.Data
{
    public class LabolatoriumDotNetNr5Context : DbContext
    {
        public LabolatoriumDotNetNr5Context (DbContextOptions<LabolatoriumDotNetNr5Context> options)
            : base(options)
        {
        }

        public DbSet<LabolatoriumDotNetNr5.Models.Book> Book { get; set; } = default!;
    }
}
