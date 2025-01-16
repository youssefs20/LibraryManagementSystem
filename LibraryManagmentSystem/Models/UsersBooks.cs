namespace LibraryManagmentSystem.Models
{
    public class UsersBooks
    {
        public int BookId { get; set; }

        public Book? Book { get; set; }

        public string UserId { get; set; }

        public User? User { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime BorrowDate { get; set; }
    }
}
