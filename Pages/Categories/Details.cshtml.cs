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
    public class DetailsModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DetailsModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

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
    }
}
