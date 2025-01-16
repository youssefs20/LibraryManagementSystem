using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class BooksCheckedOutRepository : IBooksCheckedOutRepository
    {
        LibraryContext context;
        public BooksCheckedOutRepository(LibraryContext _context) 
        {
            context = _context;
        }
        public bool Add(BooksCheckedOut bookcheckedout)
        {
            try
            {
                context.BooksCheckedOuts.Add(bookcheckedout);
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(BooksCheckedOut bookcheckedout)
        {
            try
            {
                context.BooksCheckedOuts.Remove(bookcheckedout);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public BooksCheckedOut Get(int id)
        {
            return context.BooksCheckedOuts.FirstOrDefault(b => b.Id == id);
        }

        public List<BooksCheckedOut> GetAll()
        {
            return context.BooksCheckedOuts.ToList();
        }

        public List<BooksCheckedOut> GetBooksCheckedOutByCheckoutId(int id)
        {
            return context.BooksCheckedOuts.Where(BC => BC.CheckOutId == id).ToList();
        }

        public List<BooksCheckedOut> GetBooksCheckedOutsByReturnId(int id) 
        {
            return context.BooksCheckedOuts.Where(BC => BC.ReturnId == id).ToList();
        }

        public BooksCheckedOut GetById(int BookId,int CheckoutId)
        {
            return context.BooksCheckedOuts.FirstOrDefault(B => B.CheckOutId == CheckoutId && B.BookId == BookId);
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public bool Update(BooksCheckedOut bookcheckedout)
        {
            try
            {
                context.BooksCheckedOuts.Update(bookcheckedout);
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
