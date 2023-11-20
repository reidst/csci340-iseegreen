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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace csci340_iseegreen.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;

        public IndexModel(csci340_iseegreen.Data.ISeeGreenContext context)
        {
            _context = context;
            CategoryOptions = new List<(string, string)>();
            foreach (var cat in context.Categories)
            {
                CategoryOptions.Add((cat.Category, cat.Description));
            }
        }

        public IList<csci340_iseegreen.Models.Taxa> Taxa { get;set; } = default!;

        // List of (CategoryID, FullCategoryName) entries for all categories
        // e.g., ("F", "Fern")
        public IList<(string, string)> CategoryOptions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }

        public async Task OnGetAsync()
        {
            var taxon = from m in _context.Taxa
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                taxon = taxon.Where(s => s.SpecificEpithet.Contains(SearchString ?? ""));
            }
            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                taxon = taxon.Where(s => s.Genus.Family.CategoryID.Contains(CategoryFilter ?? ""));
            }

            Taxa = await taxon.ToListAsync();
        }
    }
}
