using LibraryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        LibraryContext context;
        public ProfileRepository(LibraryContext _context)
        {
            context = _context;
        }
        public bool Add(string UserId)
        {
            try
            {
                Profile profile = new Profile();
                profile.MemberId = UserId;
                context.Profile.Add(profile);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Profile Profile)
        {
            try
            {
                context.Profile.Remove(Profile);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Profile> GetAll()
        {
            return context.Profile.ToList();
        }

        public Profile GetById(string id)
        {
            return context.Profile.Include("Member").Include(P => P.BorrowedBooks).ThenInclude(PB => PB.Book).FirstOrDefault(C => C.MemberId == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Update(Profile Profile)
        {
            try
            {
                context.Profile.Update(Profile);
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
