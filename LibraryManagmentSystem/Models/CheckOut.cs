using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.Models
{
    public class CheckOut
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Member))]
        public string? MemberId { get; set; }
        public User? Member { get; set; }
        [ForeignKey(nameof(Librarian))]
        public string? LibrarianId { get; set; }
        public User? Librarian { get; set; }

        public int status { get; set; } = 0; //0 => Not Sent ; 1 => Sent ; 2 => Accepted ; 3 => Rejected
        public List<BooksCheckedOut>? booksCheckedOuts { get; set; }
    }
}
