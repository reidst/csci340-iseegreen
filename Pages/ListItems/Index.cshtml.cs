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
    public class IndexModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public IndexModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        public IList<ListItems> ListItems { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ListItems != null)
            {
                ListItems = await _context.ListItems
                .Include(l => l.List)
                .Include(l => l.Location)
                .Include(l => l.Plant).ToListAsync();
            }
        }
    }
}
