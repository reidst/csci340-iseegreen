using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DeleteModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public csci340_iseegreen.Models.Categories Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FirstOrDefaultAsync(m => m.Category == id);

            if (categories == null)
            {
                return NotFound();
            }
            else 
            {
                Categories = categories;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }
            var categories = await _context.Categories.FindAsync(id);

            if (categories != null)
            {
                Categories = categories;
                _context.Categories.Remove(Categories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
