using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VasosInteligentes.Models;
using VasosInteligentes.ViewModel;

namespace VasosInteligentes.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required][EmailAddress] string email,
            [Required] string username,
            [Required] string password
            )
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = username,
                    Email = email
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
                return NotFound();

            user.Email = model.Email;
            user.UserName = model.Username;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("Index");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return RedirectToAction("Index");

            if (user.Id == _userManager.GetUserId(User))
            {
                TempData["Erro"] = "Você não pode excluir seu próprio usuário.";
                return RedirectToAction("Index");
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                TempData["Erro"] = string.Join(" | ", result.Errors.Select(e => e.Description));
            }

            return RedirectToAction("Index");
        }
    }
}