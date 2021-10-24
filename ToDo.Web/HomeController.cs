using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Services;
using ToDo.Core.Entities;
using ToDo.Infrastructure.Identity;

namespace ToDo.Web
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITodoItemService _iTodoItemService;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITodoItemService iTodoItemService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iTodoItemService = iTodoItemService;
        }



        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Index()
        {

            User u = new User();
            u.Id = "testuser1";
            var col = await _iTodoItemService.GetIncompleteItemsAsync(u);
            return View(col);
           
        }


    

        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait(false);


            if (user == null)
            {
                RedirectToAction("Login");
            }
            //login functionality  

            return View(user);
        }


    }
}
