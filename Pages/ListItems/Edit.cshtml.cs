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

namespace csci340_iseegreen.Pages_ListItems
{
    public class EditModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public EditModel(csci340_iseegreen.Data.ISeeGreenContext context)
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

            var listitems =  await _context.ListItems.FirstOrDefaultAsync(m => m.KewID == id);
            if (listitems == null)
            {
                return NotFound();
            }
            ListItems = listitems;
           ViewData["ListID"] = new SelectList(_context.Lists, "Id", "Id");
           ViewData["LocationID"] = new SelectList(_context.Locations, "Id", "Id");
           ViewData["KewID"] = new SelectList(_context.Taxa, "KewID", "KewID");
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

            _context.Attach(ListItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListItemsExists(ListItems.KewID))
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

        private bool ListItemsExists(string id)
        {
          return (_context.ListItems?.Any(e => e.KewID == id)).GetValueOrDefault();
        }
    }
}
