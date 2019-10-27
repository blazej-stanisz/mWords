using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mWords.Data;
using mWords.Models;
using mWords.Models.ApplicationModels;
using mWords.Models.EntityModels;
using mWords.Models.ViewModels;
using mWords.Providers;
using mWords.Providers.Interfaces;
using mWords.Providers.Common;
using mWords.Providers.Extensions;

namespace mWords.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDictionarySetsProvider _dsp;
        private readonly IDictionaryEntriesProvider _dep;
        private readonly IEntryAssignmentsProvider _eap;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper, 
            IDictionarySetsProvider dsp, IDictionaryEntriesProvider dep, IEntryAssignmentsProvider eap)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _dsp = dsp;
            _dep = dep;
            _eap = eap;
        }

        public IActionResult Index()
        {
            var indexViewModel = new HomeIndexViewModel();
            indexViewModel.dictionarySets = _dsp.GetAll();

            var res1 = _dsp.Get(1);
            var res2 = _dep.Get(1);
            var res3 = _eap.Get(1);
            //var res4 = _eap.GetQueryable().Include(z => z.DictionaryEntry).FirstOrDefault(x => x.Id == 1);
            //var res4x = _context.Find(1)
            var res5 = _eap.Get(x => x.Id == 1 || x.Id == 2);
            var res6 = _eap.GetTest(1, ip => ip.Include(p => p.DictionaryEntry).Include(a => a.ApplicationUser));
            var res7 = _eap.GetTest2(x => x.Id == 1, ip => ip.Include(p => p.DictionaryEntry).Include(a => a.ApplicationUser));

            var res8 = _eap.GetTest(1);
            var res9 = _eap.GetTest2(x => x.Id == 1);

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
