using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Interfaces;
using ToDo.Application.Services;
using ToDo.Core.Entities;
using ToDo.Infrastructure.Identity;

namespace ToDo.Web
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
    }      


    }
}
