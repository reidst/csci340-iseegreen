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
using Microsoft.Extensions.Configuration;

namespace csci340_iseegreen.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly csci340_iseegreen.Data.ISeeGreenContext _context;
        private readonly IConfiguration Configuration;
        public IndexModel(csci340_iseegreen.Data.ISeeGreenContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
            CategoryOptions = new List<(string, string)>();
            foreach (var cat in context.Categories)
            {
                CategoryOptions.Add((cat.Category, cat.Description));
            }
        }

        public PaginatedList<csci340_iseegreen.Models.Taxa> Taxa { get;set; } = default!;

        // List of (CategoryID, FullCategoryName) entries for all categories
        // e.g., ("F", "Fern")
        public IList<(string, string)> CategoryOptions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FamilyString { get; set; }

        public SelectList? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }

        public string SpeciesSort {get; set;}
        public string GenusSort {get; set;}
        public string CurrentFilter {get; set;}


        public async Task OnGetAsync(string sortOrder, string SearchString, int? pageIndex)
        {
            SpeciesSort = String.IsNullOrEmpty(sortOrder) ? "species": "";
            GenusSort = String.IsNullOrEmpty(sortOrder) ? "genus": "";

            IQueryable<csci340_iseegreen.Models.Taxa> taxaIQ = from t in _context.Taxa select t; 

            switch (sortOrder) {
                case "species":
                    taxaIQ = taxaIQ.OrderBy(s => s.SpecificEpithet);
                    break;

                case "genus":
                    taxaIQ = taxaIQ.OrderBy(s => s.Genus);
                    break;

                default: 
                    taxaIQ = taxaIQ.OrderBy(s => s.Genus);
                    break;
            }

            var taxon = from m in _context.Taxa
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                taxaIQ = taxaIQ.Where(s => s.SpecificEpithet.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(FamilyString))
            {
                taxaIQ = taxaIQ.Where(s => s.Genus.FamilyID.Contains(FamilyString));
            }
            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                taxaIQ = taxaIQ.Where(s => s.Genus.Family.CategoryID.Contains(CategoryFilter));
            }

            var pageSize = Configuration.GetValue("PageSize", 10);
            Taxa = await PaginatedList<csci340_iseegreen.Models.Taxa>.CreateAsync(
            taxaIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
