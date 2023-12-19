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
    public class DetailsModel : PageModel
    {
        private readonly lab5Dotnet_V2.Data.lab5Dotnet_V2Context _context;

        public DetailsModel(lab5Dotnet_V2.Data.lab5Dotnet_V2Context context)
        {
            _context = context;
        }

        public Books Books { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                Books = books;
            }
            return Page();
        }
    }
}
