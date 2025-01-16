using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();

        public User GetById(string id);

        public bool Add(User User);
        public bool Update(User User);
        public bool Delete(User User);
        public void Save();
    }
}
