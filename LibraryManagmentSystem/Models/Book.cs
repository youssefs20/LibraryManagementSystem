namespace LibraryManagmentSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[]? img { get; set; }
        public int quantity { get; set; }
    }
}
