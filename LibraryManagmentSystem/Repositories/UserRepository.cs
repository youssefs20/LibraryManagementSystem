using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        LibraryContext context;
        public UserRepository(LibraryContext _context)
        {
            context = _context;
        }
        public bool Add(User User)
        {
            try
            {
                context.Users.Add(User);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(User User)
        {
            try
            {
                context.Users.Remove(User);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(string id)
        {
            return context.Users.FirstOrDefault(C => C.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Update(User User)
        {
            try
            {
                context.Users.Update(User);
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
