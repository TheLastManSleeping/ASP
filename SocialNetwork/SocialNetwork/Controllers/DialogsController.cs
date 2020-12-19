using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Repositories;

namespace SocialNetwork.Controllers
{
    public class DialogsController : Controller
    {
        UserManager<User> _userManager;
        IRepository<Dialog> _dialogRepository;
        IRepository<Message> _messageRepository;

        public DialogsController(UserManager<User> userManager, IRepository<Dialog> dialogRepository, IRepository<Message> messageRepository)
        {
            _userManager = userManager;
            _dialogRepository = dialogRepository;
            _messageRepository = messageRepository;
        }
        
        public IActionResult Index(string id)
        {
            var dialog = _dialogRepository.GetEntity(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            var dialog2 = _dialogRepository.GetEntity(id,User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (dialog == null)
            {
                dialog = new Dialog();
                dialog.FriendId = id;
                dialog.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _dialogRepository.SaveEntity(dialog);
            }

            var messages = _messageRepository.GetAllEntities();
            List<Message> _messages = new List<Message>();
            foreach (var message in messages)
            {
                if (message.DialogId == dialog.Id || message.DialogId == dialog2.Id)
                {
                    _messages.Add(message);
                }
            }

            ViewBag.messages = _messages;
            ViewBag.IDD = dialog.Id;
            return View(ViewBag);
        }
        
        public IActionResult Dialogs()
        {
            var dialogs = _dialogRepository.GetAllEntities();
            List<Dialog> _dialogs = new List<Dialog>();
            foreach (var dialog in dialogs)
            {
                if (dialog.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    _dialogs.Add(dialog);
                }

                ViewBag.dialogs = _dialogs;
                ViewBag.Users = _userManager.Users.ToList();
            }
            return View(ViewBag);
        }

    }
}