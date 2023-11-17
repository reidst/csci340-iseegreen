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

namespace csci340_iseegreen.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public IndexModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
        }

        public IList<csci340_iseegreen.Models.Taxa> Taxa { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Category { get; set; }

        public async Task OnGetAsync()
        {
            var taxon = from m in _context.Taxa
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                taxon = taxon.Where(s => s.SpecificEpithet.Contains(SearchString));
            }

            Taxa = await taxon.ToListAsync();
        }
    }
}
