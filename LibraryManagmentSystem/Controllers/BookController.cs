using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Repositories;
using LibraryManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Controllers
{
    [Authorize(Roles = "Librarian")]
    public class BookController : Controller
    {
        IBookRepository bookRepo;
        public BookController(IBookRepository bookRepository)
        {
            bookRepo = bookRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Book> books = bookRepo.GetAll();
            return View("Index", books);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View("AddBook");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddBook(BookViewModel bookviewmodel)
        {
            if (ModelState.IsValid) 
            {
                var book = new Book
                {
                    Title = bookviewmodel.Title,
                    quantity = bookviewmodel.Quantity
                };
                if (bookviewmodel.Img != null && bookviewmodel.Img.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await bookviewmodel.Img.CopyToAsync(memoryStream);
                        book.img = memoryStream.ToArray();
                    }
                }
                bookRepo.Add(book);
                bookRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddBook",bookviewmodel);
            }
        }
        [AllowAnonymous]
        public IActionResult GetImage(int id)
        {
            var book = bookRepo.GetById(id);
            if (book?.img != null)
            {
                return File(book.img, "image/jpeg"); // Adjust MIME type as needed (e.g., "image/png")
            }

            return NotFound(); // Return a 404 if no image exists
        }

        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            var book = bookRepo.GetById(id);
            BookViewModel bookViewModel = new BookViewModel
            {
                Id = id,
                Title = book.Title,
                Quantity = book.quantity
            };
            return View("UpdateBook",bookViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBook(BookViewModel bookviewmodel)
        {
            if (ModelState.IsValid) 
            {
                var book = bookRepo.GetById(bookviewmodel.Id);
                book.Title = bookviewmodel.Title;
                book.quantity = bookviewmodel.Quantity;
                if (bookviewmodel.Img != null && bookviewmodel.Img.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await bookviewmodel.Img.CopyToAsync(memoryStream);
                        book.img = memoryStream.ToArray();
                    }
                }
                bookRepo.Update(book);
                bookRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("UpdateBook",bookviewmodel);
            }
        }

        public IActionResult DeleteBook(int id) 
        {
            var book = bookRepo.GetById(id);
            bookRepo.Delete(book);
            bookRepo.Save();
            return RedirectToAction("Index");
        }

    }
}
