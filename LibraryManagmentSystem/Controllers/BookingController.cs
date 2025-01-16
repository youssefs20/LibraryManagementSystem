using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace LibraryManagmentSystem.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        IBookRepository bookRepository;
        ICheckOutRepository checkOutRepository;
        IBooksCheckedOutRepository bookCheckedOutRepository;
        IUsersBooks usersBooks;
        IProfileRepository profileRepository;
        public BookingController(IUsersBooks usersBooks,IBookRepository bookRepository, ICheckOutRepository checkOutRepository, IBooksCheckedOutRepository booksCheckedOutRepository, IProfileRepository profileRepository)
        {
            this.bookRepository = bookRepository;
            this.checkOutRepository = checkOutRepository;
            this.usersBooks = usersBooks;
            bookCheckedOutRepository = booksCheckedOutRepository;
            this.profileRepository = profileRepository;
        }

        [Authorize(Roles ="Member")]
        public IActionResult Index() 
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var CheckOuts = checkOutRepository.GetAllCheckOutsForUser(userId);
            return View("mycheckouts",CheckOuts);
        }

        [Authorize(Roles = "Member")]
        public IActionResult MakeCheckOut(Book book) 
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var checkout = checkOutRepository.GetUserActiveCheckOut(userId);
            checkout.MemberId = userId;
            checkOutRepository.Update(checkout);
            if (!bookRepository.CheckIfUserHasBook(book.Id,userId))
            {
                checkOutRepository.Save();
                var bookcheckedout = bookCheckedOutRepository.GetById(book.Id,checkout.Id);
                if (bookcheckedout == null)
                {
                    bookcheckedout = new BooksCheckedOut
                    {
                        CheckOutId = checkout.Id,
                        BookId = book.Id,
                        ProfileId = profileRepository.GetById(userId).Id,
                        status = 0
                    };
                    bookCheckedOutRepository.Add(bookcheckedout);
                    bookCheckedOutRepository.Save();
                }
            }
            return RedirectToAction("Index","Book");
        }

        [Authorize(Roles ="Member")]
        public IActionResult ConfirmCheckOut(int id)
        {
            var checkout = checkOutRepository.GetById(id);
            if(checkout.status == 0)
            {
                checkout.status = 1;
                checkOutRepository.Update(checkout);
                checkOutRepository.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult CancelCheckOut(int id)
        {
            var checkout = checkOutRepository.GetById(id);
            if (checkout.status == 0 || checkout.status == 1)
            {
                List<BooksCheckedOut> booksCheckedOuts = bookCheckedOutRepository.GetBooksCheckedOutByCheckoutId(checkout.Id);
                foreach (var book in booksCheckedOuts)
                {
                    bookCheckedOutRepository.Delete(book);
                }
                checkOutRepository.Delete(checkout);
                checkOutRepository.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public IActionResult ViewPendingCheckOuts()
        {
            var checkouts = checkOutRepository.GetAllPendingCheckOuts();
            return View("viewcheckouts",checkouts);
        }

        public IActionResult ManageCheckOutRequests(int id)
        {
            var checkout = checkOutRepository.GetCheckout_BooksCheckedOut_User_Books(id);
            return View("managecheckout",checkout);
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public IActionResult ManageCheckout(int CheckOutId, Dictionary<int, DateTime> DueDates)
        {
            if (ModelState.IsValid) 
            {
                var checkout = checkOutRepository.GetCheckout_BooksCheckedOut_User_Books(CheckOutId);

                foreach (var bookCheckedOut in checkout.booksCheckedOuts)
                {
                    if (DueDates.ContainsKey(bookCheckedOut.Id))
                    {
                        bookCheckedOut.DueDate = DueDates[bookCheckedOut.Id];  // Assign DueDate
                        bookCheckedOut.BorrowDate = DateTime.Now;  // Assign BorrowDate to current time
                        bookCheckedOut.status = 1;
                    }
                }
                checkout.status = 2;
                string LibrarianId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                checkout.MemberId = LibrarianId;
                checkOutRepository.Save();
            }
            return RedirectToAction("ViewPendingCheckOuts");  // Redirect back to the manage checkouts page
        }
    }
}
