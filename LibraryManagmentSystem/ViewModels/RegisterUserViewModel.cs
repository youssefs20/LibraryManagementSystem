using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.ViewModels
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ComfirmPassword { get; set; }
    }
}
