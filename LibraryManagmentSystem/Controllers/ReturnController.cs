using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.Controllers
{
    [Authorize]
    public class ReturnController : Controller
    {
        IBookRepository bookRepository;
        ICheckOutRepository checkOutRepository;
        IBooksCheckedOutRepository bookCheckedOutRepository;
        IProfileRepository profileRepository;
        IReturnRepository returnRepository;
        public ReturnController(IReturnRepository returnRepository, IBookRepository bookRepository, ICheckOutRepository checkOutRepository, IBooksCheckedOutRepository booksCheckedOutRepository, IProfileRepository profileRepository)
        {
            this.bookRepository = bookRepository;
            this.checkOutRepository = checkOutRepository;
            bookCheckedOutRepository = booksCheckedOutRepository;
            this.profileRepository = profileRepository;
            this.returnRepository = returnRepository;
        }


        [Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var returns = returnRepository.GetAllreturnsForUser(userId);
            return View("myreturns", returns);
        }

        [Authorize(Roles = "Member")]
        public IActionResult MakeReturn(int id)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var returnreq = returnRepository.GetUserActiveReturns(userId);
            returnreq.MemberId = userId;
            returnRepository.Update(returnreq);
            returnRepository.Save(); // Save the Return entity first

            var bookcheckedout = bookCheckedOutRepository.Get(id);
            bookcheckedout.ReturnId = returnreq.Id; // Use the saved Return entity's Id
            bookCheckedOutRepository.Update(bookcheckedout); // Update the BooksCheckedOuts entity
            bookCheckedOutRepository.Save(); // Save the BooksCheckedOuts entity

            return RedirectToAction("Index", "Return");
        }

        [Authorize(Roles ="Member")]
        public IActionResult ConfirmReturn(int id)
        {
            var returnreq = returnRepository.GetById(id);
            if (returnreq.status == 0)
            {
                returnreq.status = 1;
                returnRepository.Update(returnreq);
                returnRepository.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="Member")]
        public IActionResult CancelReturn(int id)
        {
            var returnreq = returnRepository.GetById(id);
            if (returnreq.status == 0 || returnreq.status == 1)
            {
                List<BooksCheckedOut> booksCheckedOuts = bookCheckedOutRepository.GetBooksCheckedOutsByReturnId(returnreq.Id);
                foreach (var book in booksCheckedOuts)
                {
                    book.ReturnId = null;
                }
                bookCheckedOutRepository.Save();
                returnRepository.Delete(returnreq);
                returnRepository.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Librarian")]
        public IActionResult ViewReturnRequests() 
        {
            var returns = returnRepository.GetReturnRequests();
            return View("ViewReturnRequests", returns);
        }

        [Authorize(Roles ="Librarian")]
        public IActionResult AcceptReturn(int id) 
        {
            int penalty = 0;
            int OverDueCharge = 2;
            var returnreq = returnRepository.GetById(id);
            foreach(var returnedbook in returnreq.ReturnedBooks)
            {
                returnedbook.status = 2;
                if(DateTime.Now > returnedbook.DueDate)
                {
                    TimeSpan overdue = DateTime.Now - returnedbook.DueDate;
                    int overdays = overdue.Days > 0 ? overdue.Days : 0;
                     penalty += (overdays * OverDueCharge);
                }
            }
            bookCheckedOutRepository.Save();
            returnreq.status = 2;
            returnreq.Penalty = penalty;
            string librarianId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            returnreq.LibrarianId = librarianId;
            returnRepository.Save();
            return RedirectToAction("ViewReturnRequests");
        }
    }
}
