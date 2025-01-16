using LibraryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Repositories
{
    public class ReturnRepository : IReturnRepository
    {
        LibraryContext context;
        public ReturnRepository(LibraryContext _context)
        {
            context = _context;
        }
        public bool Add(Return Return)
        {
            try
            {
                context.Returns.Add(Return);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Return Return)
        {
            try
            {
                context.Returns.Remove(Return);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Return> GetAll()
        {
            return context.Returns.ToList();
        }

        public Return GetById(int id)
        {
            return context.Returns.Include(r => r.ReturnedBooks).FirstOrDefault(C => C.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Update(Return Return)
        {
            try
            {
                context.Returns.Update(Return);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Return> GetAllreturnsForUser(string userId)
        {
            return context.returns.Include(r => r.ReturnedBooks).ThenInclude(b => b.Book).Where(R => R.MemberId == userId).ToList();
        }

        public Return GetUserActiveReturns(string userId)
        {
            var returnreq = context.returns.FirstOrDefault(c => c.MemberId == userId && c.status == 0);
            if (returnreq == null)
            {
                returnreq = new Return();
                return returnreq;
            }
            else
            {
                return returnreq;
            }
        }
        public List<Return> GetReturnRequests()
        {
            return context.Returns.Include(r => r.Member).Include(r => r.ReturnedBooks).ThenInclude(b => b.Book).Where(R => R.status == 1).ToList();
        }

    }
}

