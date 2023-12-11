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
    public class DetailsModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public DetailsModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

      public ListItems ListItems { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ListItems == null)
            {
                return NotFound();
            }

            var listitems = await _context.ListItems.Include(l => l.Plant).Include(v => v.List).Include(g => g.Plant!.Genus).Include(f => f.Plant!.Genus!.Family).Include(c => c.Plant!.Genus!.Family!.Category).FirstOrDefaultAsync(m => m.KewID == id);
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
    }
}
