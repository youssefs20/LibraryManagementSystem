using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class BooksReturnedRepository : IBooksReturnedRepository
    {
        LibraryContext context;
        public BooksReturnedRepository(LibraryContext _context)
        {
            context = _context;
        }
        public bool Add(BooksReturned BooksReturned)
        {
            try
            {
                context.BooksReturned.Add(BooksReturned);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(BooksReturned BooksReturned)
        {
            try
            {
                context.BooksReturned.Remove(BooksReturned);
                return true;    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<BooksReturned> GetAll()
        {
            return context.BooksReturned.ToList();
        }

        public BooksReturned GetById(int id)
        {
            return context.BooksReturned.FirstOrDefault(B => B.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Update(BooksReturned BooksReturned)
        {
            try
            {
                context.Update(BooksReturned);
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
