using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Repositories;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IError<int> _error;

        public HomeController(IError<int> error)
        {
            _error = error;
        }


        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("UserPage", "User");
            ViewBag.Err = _error.Err();
            return View(ViewBag);
        }
        

    }
}