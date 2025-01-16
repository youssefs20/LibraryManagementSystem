using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface IBooksCheckedOutRepository
    {
        public List<BooksCheckedOut> GetAll();

        public BooksCheckedOut Get(int id);
        public BooksCheckedOut GetById(int id,int CheckoutId);

        public bool Add(BooksCheckedOut bookcheckedout);
        public bool Update(BooksCheckedOut bookcheckedout);
        public bool Delete(BooksCheckedOut bookcheckedout);

        public List<BooksCheckedOut> GetBooksCheckedOutByCheckoutId(int id);

        public List<BooksCheckedOut> GetBooksCheckedOutsByReturnId(int id);
        public void Save();
    }
}
