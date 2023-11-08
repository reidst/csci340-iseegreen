using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340_iseegreen.Data;
using csci340_iseegreen.Models;

namespace csci340_iseegreen.Pages.Families
{
    public class DetailsModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DetailsModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

      public csci340_iseegreen.Models.Families Families { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Families == null)
            {
                return NotFound();
            }

            var families = await _context.Families.FirstOrDefaultAsync(m => m.family == id);
            if (families == null)
            {
                return NotFound();
            }
            else 
            {
                Families = families;
            }
            return Page();
        }
    }
}
