using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWX17.Workshop.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DWX17.Workshop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITextService _textService;

        public HomeController(ITextService textService)
        {
            _textService = textService;
        }
        public IActionResult Index()
        {
            ViewBag.Message = _textService.GetText();
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
