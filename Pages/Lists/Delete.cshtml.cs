using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages_Lists
{
    public class DeleteModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DeleteModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Lists Lists { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lists == null)
            {
                return NotFound();
            }

            var lists = await _context.Lists.FirstOrDefaultAsync(m => m.Id == id);

            if (lists == null)
            {
                return NotFound();
            }
            else 
            {
                Lists = lists;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Lists == null)
            {
                return NotFound();
            }
            var lists = await _context.Lists.FindAsync(id);

            if (lists != null)
            {
                Lists = lists;
                _context.Lists.Remove(Lists);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
