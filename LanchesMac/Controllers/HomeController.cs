﻿using LanchesMac.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesMac.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //adicionado
        public IActionResult Demo()
        {
            return View();
        }
    }
}