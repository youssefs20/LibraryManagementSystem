using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class UsersBooksRepository : IUsersBooks
    {
        LibraryContext context;
        public UsersBooksRepository(LibraryContext context) 
        {
            this.context = context;
        }
        public void DeleteUserBook(string Userid, int Bookid)
        {
            var book = context.UsersBooks.FirstOrDefault(UB => UB.UserId == Userid && UB.BookId == Bookid);
               context.Remove(book);
        }

        public bool GetBook(string Userid, int Bookid)
        {
            var book = context.UsersBooks.FirstOrDefault(UB => UB.UserId == Userid && UB.BookId == Bookid);
            if(book == null)
                return false;
            else
                return true;
        }

        public List<UsersBooks> GetUsersBooks(string Userid)
        {
            return context.UsersBooks.Where(UB => UB.UserId == Userid).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
