using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Repositories;
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    public class UserController : Controller
    {

        UserManager<User> _userManager;
        IRepository<Friend> _friendRepository;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _environment;
 
 
        public UserController(UserManager<User> userManager, IRepository<Friend> friendRepository, IImageService imageService, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _friendRepository = friendRepository;
            _imageService = imageService;
            _environment = environment;
        }
        
        public async Task<ActionResult> UserPage(string id)
        {
            if (id == null)
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = await  _userManager.FindByIdAsync(id);
            UserInfoViewModel model = new UserInfoViewModel {Id = id, Email = user.Email, Name = user.Name, Surname = user.Surname, Country = user.Country, BirthDay = user.BirthDay, UserName = user.UserName, Gender = user.Gender, Photo = user.Photo};
            return View(model);
        }
 
        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Friends()
        {
            ViewBag.Users = _userManager.Users.ToList();
            ViewBag.Friends = _friendRepository.GetAllEntities().ToList();
            return View(ViewBag);
        }
 
        public IActionResult Create() => View();
 
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
 
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel {Id = user.Id, Name = user.Name, Surname = user.Surname, Country = user.Country, Gender = user.Gender};
            return View(model);
        }
 
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if(user!=null)
                {
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Country = model.Country;
                    user.Gender = model.Gender;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserPage");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }
 
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email};
            return View(model);
        }
 
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var _passwordValidator = 
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;
     
                    IdentityResult result = 
                        await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if(result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
        
        
        public async Task<ActionResult> AddFriend(string id)
        {
            Friend friend = new Friend();
            
            foreach(var user in _userManager.Users.ToList())
            {
                if(user.Id == id)
                    friend.FriendName = user.UserName;
            }

            string idCur = User.FindFirstValue(ClaimTypes.NameIdentifier);

            friend.FriendId = id;
            friend.IdUser = idCur;

            _friendRepository.SaveEntity(friend);
            return RedirectToAction("Friends");
        }

        public async Task<ActionResult> DeleteFriend(string id)
        {
            foreach(var user in _friendRepository.GetAllEntities().ToList())
            {
                if (user.FriendId == id && User.FindFirstValue(ClaimTypes.NameIdentifier) == user.IdUser)
                {
                    _friendRepository.DeleteEntity(user);
                    break;
                }
            }
            
            return RedirectToAction("Friends");
        }
        
        public async Task<ActionResult> GetImage(string id)
        {
            return File(id, "image/png");
        }

    }
}