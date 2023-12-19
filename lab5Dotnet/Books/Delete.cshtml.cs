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
    public class DeleteModel : PageModel
    {
        private readonly lab5Dotnet.Data.lab5DotnetContext _context;

        public DeleteModel(lab5Dotnet.Data.lab5DotnetContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FindAsync(id);
            if (library != null)
            {
                Library = library;
                _context.Library.Remove(Library);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
