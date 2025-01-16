using LibraryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Repositories
{
    public class CheckOutRepository : ICheckOutRepository
    {
        LibraryContext context;
        public CheckOutRepository(LibraryContext _context) 
        {
            context = _context;
        }
        public bool Add(CheckOut CheckOut)
        {
            try
            {
                context.CheckOuts.Add(CheckOut);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public bool Delete(CheckOut CheckOut)
        {
            try
            {
                context.CheckOuts.Remove(CheckOut);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<CheckOut> GetAll()
        {
            return context.CheckOuts.ToList();
        }

        public List<CheckOut> GetAllCheckOutsForUser(string userId)
        {
            return context.CheckOuts
            .Include(c => c.booksCheckedOuts) // Include the list of BooksCheckedOuts
            .ThenInclude(bc => bc.Book)       // Include the related Book entity for each BooksCheckedOut
            .Where(c => c.MemberId == userId)
            .ToList();
        }

        public List<CheckOut> GetAllPendingCheckOuts()
        {
            return context.CheckOuts.Include(c => c.Member).Include(c => c.booksCheckedOuts)
            .ThenInclude(bc => bc.Book)
                .Where(c => c.status == 1).ToList();
        }

        public CheckOut GetCheckout_BooksCheckedOut_User_Books(int id)
        {
            return context.CheckOuts.Include(c => c.Member).Include(c => c.booksCheckedOuts)
            .ThenInclude(bc => bc.Book).FirstOrDefault(C => C.Id == id);
        }

        public CheckOut GetById(int id)
        {
            return context.CheckOuts.FirstOrDefault(C => C.Id == id);
        }

        public CheckOut GetUserActiveCheckOut(string userId)
        {
            var checkout = context.CheckOuts.FirstOrDefault(c => c.MemberId == userId && c.status == 0);
            if (checkout == null) 
            {
                checkout = new CheckOut();
                return checkout;
            }
            else
            {
                return checkout;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Update(CheckOut CheckOut)
        {
            try
            {
                context.CheckOuts.Update(CheckOut);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
