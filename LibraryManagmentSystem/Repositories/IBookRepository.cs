using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll();

        public Book GetById(int id);

        public bool Add(Book book);
        public bool Update(Book book);
        public bool Delete(Book book);
        public bool CheckIfUserHasBook(int bookId, string UserId);
        public void Save();
    }
}
