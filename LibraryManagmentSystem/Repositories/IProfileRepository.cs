using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public interface IProfileRepository
    {
        public List<Profile> GetAll();

        public Profile GetById(string id);

        public bool Add(string UserId);
        public bool Update(Profile Profile);
        public bool Delete(Profile Profile);
        public void Save();
    }
}
