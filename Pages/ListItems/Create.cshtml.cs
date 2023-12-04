using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages_ListItems
{
    public class CreateModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public CreateModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ListID"] = new SelectList(_context.Lists, "Id", "Id");
        ViewData["LocationID"] = new SelectList(_context.Locations, "Id", "Id");
        ViewData["KewID"] = new SelectList(_context.Taxa, "KewID", "KewID");
            return Page();
        }

        [BindProperty]
        public ListItems ListItems { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ListItems == null || ListItems == null)
            {
                return Page();
            }

            _context.ListItems.Add(ListItems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
