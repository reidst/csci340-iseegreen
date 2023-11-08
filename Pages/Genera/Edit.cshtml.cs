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

namespace csci340_iseegreen.Pages.Genera
{
    public class EditModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public EditModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public csci340_iseegreen.Models.Genera Genera { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Genera == null)
            {
                return NotFound();
            }

            var genera =  await _context.Genera.FirstOrDefaultAsync(m => m.genus == id);
            if (genera == null)
            {
                return NotFound();
            }
            Genera = genera;
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

            _context.Attach(Genera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneraExists(Genera.genus))
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

        private bool GeneraExists(string id)
        {
          return (_context.Genera?.Any(e => e.genus == id)).GetValueOrDefault();
        }
    }
}
