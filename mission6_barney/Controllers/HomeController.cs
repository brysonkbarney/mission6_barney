using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission6_barney.Models;
// The commented-out line below is unnecessary as it's a duplicate import.
// using mission6_barney.Models;

namespace mission6_barney.Controllers
{
    // Defines the HomeController class that inherits from the Controller base class, enabling MVC functionalities.
    public class HomeController : Controller
    {
        private MovieContext _context;

        // Constructor injects the MovieContext to interact with the database.
        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        // Returns the default view for the root page.
        public IActionResult Index()
        {
            return View();
        }

        // Returns the view for the About page.
        public IActionResult About()
        {
            return View();
        }

        // Handles the GET request to show the movie form with categories loaded into ViewBag.Categories.
        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Form", new Movie());
        }

        // Handles the POST request to submit the movie form. Validates and adds the movie to the database.
        [HttpPost]
        public IActionResult Form(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                // Refresh categories in case the form is redisplayed.
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View("Confirmation", response);
            }
            else
            {
                // If model state is invalid, reload the form with submitted data and categories.
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        // Displays a list of movies, including related categories through eager loading.
        public IActionResult MovieRecords()
        {
            var movies = _context.Movies.Include(x => x.Category).ToList();

            return View(movies);
        }

        // Handles the GET request to fetch a movie for editing.
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Form", recordToEdit);
        }

        // Handles the POST request to update a movie record.
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieRecords");
        }

        // Handles the GET request to confirm deletion of a movie record.
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories;

            return View("Delete", recordToDelete);
        }

        // Handles the POST request to delete a movie record after confirmation.
        [HttpPost]
        public IActionResult DeleteConfirmed(int MovieId)
        {
            var movieToDelete = _context.Movies.Find(MovieId);

            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieRecords");
        }
    }
}
