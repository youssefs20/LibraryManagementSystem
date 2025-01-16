using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Repositories;
using LibraryManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        IProfileRepository ProfileRepository;
        public ProfileController(IProfileRepository ProfileRepository)
        {
            this.ProfileRepository = ProfileRepository;
        }

        [Authorize(Roles = "Member")]
        public IActionResult MyProfile()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var profile = ProfileRepository.GetById(userId);
            return View("MyProfile",profile);
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> UpdateProfilePic(IFormFile ProfilePic)
        {
            if (ProfilePic != null && ProfilePic.Length > 0)
            {
                var profile = ProfileRepository.GetById(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
                using (var memoryStream = new MemoryStream())
                {
                    await ProfilePic.CopyToAsync(memoryStream);
                    profile.ProfilePic = memoryStream.ToArray();
                }
                ProfileRepository.Update(profile);
                ProfileRepository.Save();
            }
            return RedirectToAction("MyProfile");
        }

        [AllowAnonymous]
        public IActionResult GetImage(string id)
        {
            var profile = ProfileRepository.GetById(id);
            if (profile?.ProfilePic != null)
            {
                return File(profile.ProfilePic, "image/jpeg"); // Adjust MIME type as needed (e.g., "image/png")
            }

            return NotFound(); // Return a 404 if no image exists
        }

    }
}
