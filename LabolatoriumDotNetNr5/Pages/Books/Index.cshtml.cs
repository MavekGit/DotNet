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
    public class IndexModel : PageModel
    {
        private readonly LabolatoriumDotNetNr5.Data.LabolatoriumDotNetNr5Context _context;

        public IndexModel(LabolatoriumDotNetNr5.Data.LabolatoriumDotNetNr5Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
