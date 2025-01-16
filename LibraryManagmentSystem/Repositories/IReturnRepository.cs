using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface IReturnRepository
    {
        public List<Return> GetAll();

        public Return GetById(int id);

        public bool Add(Return Return);
        public bool Update(Return Return);
        public bool Delete(Return Return);

        public List<Return> GetAllreturnsForUser(string userId);

        public Return GetUserActiveReturns(string userId);

        public List<Return> GetReturnRequests();
        public void Save();
    }
}
