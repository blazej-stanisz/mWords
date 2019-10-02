using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mWords.Data;
using mWords.Models.EntityModels;

namespace mWords.Views.test
{
    public class EditModel : PageModel
    {
        private readonly mWords.Data.ApplicationDbContext _context;

        public EditModel(mWords.Data.ApplicationDbContext context)
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
           ViewData["DictionarySetId"] = new SelectList(_context.DictionarySets, "Id", "CoverColorHex");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DictionaryEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictionaryEntryExists(DictionaryEntry.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DictionaryEntryExists(int id)
        {
            return _context.DictionaryEntries.Any(e => e.Id == id);
        }
    }
}
