using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab5Dotnet_V2.Data;
using lab5Dotnet_V2.Models;

namespace lab5Dotnet_V2
{
    public class IndexModel : PageModel
    {
        private readonly lab5Dotnet_V2.Data.lab5Dotnet_V2Context _context;

        public IndexModel(lab5Dotnet_V2.Data.lab5Dotnet_V2Context context)
        {
            _context = context;
        }

        public IList<Books> Books { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();
        }
    }
}
