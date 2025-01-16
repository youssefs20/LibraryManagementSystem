using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.Models
{
    public class BooksReturned
    {
        public int Id { get; set; }
        [ForeignKey("Return")]
        public int ReturnId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Return? Return { get; set; }
    }
}
