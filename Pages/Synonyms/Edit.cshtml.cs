using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages.Synonyms
{
    public class EditModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public EditModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public csci340_iseegreen.Models.Synonyms Synonyms { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Synonyms == null)
            {
                return NotFound();
            }

            var synonyms =  await _context.Synonyms.FirstOrDefaultAsync(m => m.kew_id == id);
            if (synonyms == null)
            {
                return NotFound();
            }
            Synonyms = synonyms;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Synonyms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SynonymsExists(Synonyms.kew_id))
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

        private bool SynonymsExists(string id)
        {
          return (_context.Synonyms?.Any(e => e.kew_id == id)).GetValueOrDefault();
        }
    }
}
