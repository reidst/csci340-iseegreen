using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages.Taxa
{
    public class DeleteModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DeleteModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public csci340_iseegreen.Models.Taxa Taxa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Taxa == null)
            {
                return NotFound();
            }

            var taxa = await _context.Taxa.FirstOrDefaultAsync(m => m.kew_id == id);

            if (taxa == null)
            {
                return NotFound();
            }
            else 
            {
                Taxa = taxa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Taxa == null)
            {
                return NotFound();
            }
            var taxa = await _context.Taxa.FindAsync(id);

            if (taxa != null)
            {
                Taxa = taxa;
                _context.Taxa.Remove(Taxa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
