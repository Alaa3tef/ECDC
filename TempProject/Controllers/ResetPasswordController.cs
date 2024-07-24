using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Models;
using TempProject.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResetPasswordController : Controller
	{
        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ResetPasswordController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }


        //public async Task<IActionResult> ResetPassword(string token, string userId)
        //{
        //    if (token == null || userId == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    var model = new ResetPasswordModel { Token = token, UserId = userId };
        //    return View(model);
        //}

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

    }

}
