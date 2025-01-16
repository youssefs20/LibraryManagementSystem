using LibraryManagmentSystem.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace LibraryManagmentSystem.Repositories
{
    public interface IUsersBooks
    {
        public bool GetBook(string Userid,int Bookid);

        public List<UsersBooks> GetUsersBooks(string Userid);

        public void DeleteUserBook(string Userid,int Bookid);


        public void Save();

    }
}
