using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab5Dotnet.Data;
using lab5Dotnet.Models;

namespace lab5Dotnet.Books
{
    public class IndexModel : PageModel
    {
        private readonly lab5Dotnet.Data.lab5DotnetContext _context;

        public IndexModel(lab5Dotnet.Data.lab5DotnetContext context)
        {
            _context = context;
        }

        public IList<Library> Library { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Library = await _context.Library.ToListAsync();
        }
    }
}
