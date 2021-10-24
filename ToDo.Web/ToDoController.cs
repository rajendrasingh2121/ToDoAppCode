using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Interfaces;
using ToDo.Core.Entities;
using ToDo.Infrastructure.Identity;
using ToDo.Web.Models.ViewModel;
using ToDo.Web.ViewModel;

namespace ToDo.Web
{
    public class ToDoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITodoItemService _iTodoItemService;

        public ToDoController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITodoItemService iTodoItemService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iTodoItemService = iTodoItemService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var appuser = await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait(false);
            ToDoItemViewModel toDoItemViewModel = new ToDoItemViewModel();
            toDoItemViewModel.ToDoItems= await _iTodoItemService.GetIncompleteItemsAsync(appuser.Id);
            return View(toDoItemViewModel);


        }
        // GET: ToDoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,")] TodoItemCreateViewModel todo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var todoItem = new ToDoItem
            {
                Description = todo.Description,
                
               IsDone=false,
               UserId= currentUser.Id,

               CreateDate=DateTime.Now
            };
            var successful = await _iTodoItemService
                .AddItemAsync(todoItem);

            if (!successful)
            {
                return BadRequest(new { error = "Could not add item." });
            }


            return RedirectToAction("Index");
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
