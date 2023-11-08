using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages.Synonyms
{
    public class DeleteModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DeleteModel(csci340_iseegreen.Data.ISeeGreenContext context)
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

            var synonyms = await _context.Synonyms.FirstOrDefaultAsync(m => m.kew_id == id);

            if (synonyms == null)
            {
                return NotFound();
            }
            else 
            {
                Synonyms = synonyms;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Synonyms == null)
            {
                return NotFound();
            }
            var synonyms = await _context.Synonyms.FindAsync(id);

            if (synonyms != null)
            {
                Synonyms = synonyms;
                _context.Synonyms.Remove(Synonyms);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
