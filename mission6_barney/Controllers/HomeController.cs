using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6_barney.Models;
//using mission6_barney.Models;

namespace mission6_barney.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Form(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult MovieRecords() 
        {
            var movies = _context.Movies
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

    }
}
