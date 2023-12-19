using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabolatoriumDotNetNr5.Data;
using LabolatoriumDotNetNr5.Models;

namespace LabolatoriumDotNetNr5.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly LabolatoriumDotNetNr5.Data.LabolatoriumDotNetNr5Context _context;

        public DetailsModel(LabolatoriumDotNetNr5.Data.LabolatoriumDotNetNr5Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
