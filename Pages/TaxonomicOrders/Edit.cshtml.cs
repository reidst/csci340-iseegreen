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

namespace csci340_iseegreen.Pages.TaxonomicOrders
{
    public class EditModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public EditModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public csci340_iseegreen.Models.TaxonomicOrders TaxonomicOrders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TaxonomicOrders == null)
            {
                return NotFound();
            }

            var taxonomicorders = await _context.TaxonomicOrders.FirstOrDefaultAsync(m => m.TaxonomicOrder == id);
            if (taxonomicorders == null)
            {
                return NotFound();
            }
            TaxonomicOrders = taxonomicorders;
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

            _context.Attach(TaxonomicOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxonomicOrdersExists(TaxonomicOrders.TaxonomicOrder))
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

        private bool TaxonomicOrdersExists(string id)
        {
            return (_context.TaxonomicOrders?.Any(e => e.TaxonomicOrder == id)).GetValueOrDefault();
        }
    }
}
