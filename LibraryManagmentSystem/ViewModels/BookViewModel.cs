namespace LibraryManagmentSystem.ViewModels
{
    public class BookViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile? Img { get; set; } // Image file
        public int Quantity { get; set; }
    }

}
