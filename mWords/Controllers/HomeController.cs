using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mWords.Data;
using mWords.Models;
using mWords.Models.EntityModels;
using mWords.Models.ViewModels;

namespace mWords.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var indexViewModel = new HomeIndexViewModel();
            indexViewModel.dictionarySets = _context.DictionarySets.ToList();

            return View(indexViewModel);

            //var a = new ApplicationUser();
            //var b = new ApplicationUser(this.User.Identity.Name);
            //var a = _context.DictionaryEntries.Include(d => d.DictionarySet).ToList();
            //this.ViewData["dictionarySets"] = dictionarySets;
            //this.ViewData["Title"]
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
