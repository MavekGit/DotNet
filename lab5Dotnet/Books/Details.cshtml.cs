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
    public class DetailsModel : PageModel
    {
        private readonly lab5Dotnet.Data.lab5DotnetContext _context;

        public DetailsModel(lab5Dotnet.Data.lab5DotnetContext context)
        {
            _context = context;
        }

        public Library Library { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FirstOrDefaultAsync(m => m.Id == id);
            if (library == null)
            {
                return NotFound();
            }
            else
            {
                Library = library;
            }
            return Page();
        }
    }
}
