using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.Models
{
    public class Profile
    {
       public int Id { get; set; }
        [ForeignKey(nameof(Member))]
       public string MemberId { get; set; }

       public User? Member { get; set; }
        public byte[]? ProfilePic { get; set; }
       public List<BooksCheckedOut>? BorrowedBooks { get; set; }

        public int BorrowingLimit { get; set; } = 5;
    }
}
