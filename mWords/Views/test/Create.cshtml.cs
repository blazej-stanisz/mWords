using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using mWords.Data;
using mWords.Models.EntityModels;

namespace mWords.Views.test
{
    public class CreateModel : PageModel
    {
        private readonly mWords.Data.ApplicationDbContext _context;

        public CreateModel(mWords.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DictionarySetId"] = new SelectList(_context.DictionarySets, "Id", "CoverColorHex");
            return Page();
        }

        [BindProperty]
        public DictionaryEntry DictionaryEntry { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DictionaryEntries.Add(DictionaryEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
