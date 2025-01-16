using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.Models
{
    public class Return
    {
        public int Id { get; set; }
        public int Penalty { get; set; }
        [ForeignKey(nameof(Librarian))]
        public string? LibrarianId { get; set; }

        public User? Librarian { get; set; }
        [ForeignKey(nameof(Member))]
        public string? MemberId { get; set; }
        public User? Member { get; set; }
        public List<BooksCheckedOut>? ReturnedBooks { get; set; }

        public int status { get; set; } = 0; // 0 => Not Sent , 1 => Sent , 2 => Successful Returning Opertaion
    }
}
