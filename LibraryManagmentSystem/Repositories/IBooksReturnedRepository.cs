using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface IBooksReturnedRepository
    {
        public List<BooksReturned> GetAll();

        public BooksReturned GetById(int id);

        public bool Add(BooksReturned book);
        public bool Update(BooksReturned book);
        public bool Delete(BooksReturned book);
        public void Save();
    }
}
