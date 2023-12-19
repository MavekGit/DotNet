using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LabolatoriumDotNetNr5.Data;
using LabolatoriumDotNetNr5.Models;

namespace LabolatoriumDotNetNr5.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LabolatoriumDotNetNr5.Data.LabolatoriumDotNetNr5Context _context;

        public CreateModel(LabolatoriumDotNetNr5.Data.LabolatoriumDotNetNr5Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
