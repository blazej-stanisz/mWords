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
        private readonly IDictionarySetsProvider _dictionarySetsProvider;
        private readonly IDictionaryEntriesProvider _dictionaryEntriesProvider;
        private readonly IEntryAssignmentsProvider _entryAssignmentsProvider;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper, 
            IDictionarySetsProvider dictionarySetsProvider, IDictionaryEntriesProvider dictionaryEntriesProvider, IEntryAssignmentsProvider entryAssignmentsProvider)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _dictionarySetsProvider = dictionarySetsProvider;
            _dictionaryEntriesProvider = dictionaryEntriesProvider;
            _entryAssignmentsProvider = entryAssignmentsProvider;
        }

        public IActionResult Index()
        {
            var indexViewModel = new HomeIndexViewModel();
            var dictionarySets =_dictionarySetsProvider.GetAll();

            //TODO get data for particular user
            var setsInProgressEntities = _entryAssignmentsProvider.GetQueryable().Select(s => s.DictionaryEntry.DictionarySet).Distinct();            
            foreach (var item in dictionarySets)
            {
                if (setsInProgressEntities.Any(s => s.Id == item.Id))
                {
                    item.Status = AppModelEnums.DictionarySetStatus.InProgress;
                    var inProgress = _entryAssignmentsProvider.GetQueryable().Count(x => x.DictionaryEntry.DictionarySet.Id == item.Id);
                    var allInSet = _dictionaryEntriesProvider.GetQueryable().Count(x => x.DictionarySet.Id == item.Id);
                    item.Progress = (int)Math.Ceiling((decimal)inProgress / (decimal)allInSet * 100);
                }
            }

            indexViewModel.dictionarySets = dictionarySets;

            return View(indexViewModel);


            //var indexViewModel = new HomeIndexViewModel();
            //var dictionarySets = _dsp.GetAll();

            //var res1 = _eap.Get(x => x.Id == 1 || x.Id == 2);
            //var res2 = _eap.Get(x => x.Id == 1 || x.Id == 2, ic => ic.Include(p => p.DictionaryEntry).Include(o=>o.ApplicationUser));

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
