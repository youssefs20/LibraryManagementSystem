using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Models
{
    public class BooksCheckedOut
    {

        public int Id { get; set; }
        public  int CheckOutId { get; set; }

        public  CheckOut? CheckOut { get; set; }
        public  int BookId { get; set; }
        public  Book? Book { get; set; }

        public int? ReturnId { get; set; }

        public Return? Return { get; set; }

        public int ProfileId { get; set; }
        public Profile? Profile { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        public int status { get; set; } // 0 => PendingRequest , 1 => WithUser , 2 => Returned
    }
}
