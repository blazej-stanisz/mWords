using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mWords.Data;
using mWords.Models.EntityModels;

namespace mWords.Views.test
{
    public class IndexModel : PageModel
    {
        private readonly mWords.Data.ApplicationDbContext _context;

        public IndexModel(mWords.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DictionaryEntry> DictionaryEntry { get;set; }

        public async Task OnGetAsync()
        {
            DictionaryEntry = await _context.DictionaryEntries
                .Include(d => d.DictionarySet).ToListAsync();
        }
    }
}
