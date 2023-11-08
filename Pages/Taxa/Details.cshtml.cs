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
    public class DetailsModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DetailsModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

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
    }
}
