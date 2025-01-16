using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name = "Role NAme")]
        public string RoleName { get; set; }
    }
}
