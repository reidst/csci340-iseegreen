using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages_ListItems
{
    public class DeleteModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DeleteModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ListItems ListItems { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ListItems == null)
            {
                return NotFound();
            }

            var listitems = await _context.ListItems.FirstOrDefaultAsync(m => m.KewID == id);

            if (listitems == null)
            {
                return NotFound();
            }
            else 
            {
                ListItems = listitems;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ListItems == null)
            {
                return NotFound();
            }
            var listitems = await _context.ListItems.FindAsync(id);

            if (listitems != null)
            {
                ListItems = listitems;
                _context.ListItems.Remove(ListItems);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
