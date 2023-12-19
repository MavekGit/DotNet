using lab5Dotnet_V2.Data;
using lab5Dotnet_V2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab5Dotnet_V2.Controllers
{
    public class BookController : Controller
    {
        private readonly lab5Dotnet_V2Context _db;

        public BookController(lab5Dotnet_V2Context db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Books> objBookList = _db.Books;
            return View(objBookList);
        }


        public IActionResult Create()
        {
            
            return View();
        }


    }
}
