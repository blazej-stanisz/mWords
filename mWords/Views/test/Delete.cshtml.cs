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
    public class DeleteModel : PageModel
    {
        private readonly mWords.Data.ApplicationDbContext _context;

        public DeleteModel(mWords.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DictionaryEntry DictionaryEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DictionaryEntry = await _context.DictionaryEntries
                .Include(d => d.DictionarySet).FirstOrDefaultAsync(m => m.Id == id);

            if (DictionaryEntry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DictionaryEntry = await _context.DictionaryEntries.FindAsync(id);

            if (DictionaryEntry != null)
            {
                _context.DictionaryEntries.Remove(DictionaryEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
