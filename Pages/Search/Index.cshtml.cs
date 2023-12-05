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
using System.Drawing;

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
        public List<string> Families {get; set;}
        // List of (CategoryID, FullCategoryName) entries for all categories
        // e.g., ("F", "Fern")
        public IList<(string, string)> CategoryOptions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FamilyString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? GenusString { get; set; }

        public SelectList? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }

        public string SpeciesSort {get; set;}
        public string GenusSort {get; set;}
        public string CurrentSpecies {get; set;}
        public string CurrentGenus {get; set;}
        public string CurrentFamily {get; set;}
        public string CurrentSort {get; set;}
        public string CurrentFilter {get;set;}
        public string CurrentCat {get; set;}



        public async Task OnGetAsync(string sortOrder, string FamilyString, string GenusString, string SearchString, string? CategoryFilter, int? pageIndex)
        {
            GenusSort = (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("genus_desc"))? "genus": "genus_desc";
            SpeciesSort = String.IsNullOrEmpty(sortOrder)? "species_desc": "";
            
            
            if (CategoryFilter != null) {
                CurrentCat = CategoryFilter;
            }

            CurrentSort = sortOrder;
            IQueryable<csci340_iseegreen.Models.Taxa> taxaIQ = from t in _context.Taxa.Include(g => g.Genus).Include(f => f.Genus!.Family).Include(c => c.Genus!.Family!.Category) select t;
            

            if (SearchString != null) {
                CurrentSpecies = SearchString;
            }
            else {
                SearchString = CurrentSpecies;
            }

            if (GenusString != null) {
                CurrentGenus = GenusString;
    
            }
            else {
                GenusString = CurrentGenus;
            }

            if (FamilyString != null) {
                CurrentFamily = FamilyString;
    
            }
            else {
                FamilyString = CurrentFamily;
            }
            


            if (!string.IsNullOrEmpty(SearchString))
            {
                taxaIQ = taxaIQ.Where(s => s.SpecificEpithet.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(FamilyString))
            {
                taxaIQ = taxaIQ.Where(s => s.Genus.FamilyID.Contains(FamilyString));
            }
            if (!string.IsNullOrEmpty(GenusString))
            {
                taxaIQ = taxaIQ.Where(s => s.GenusID.Contains(GenusString));
            }
            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                taxaIQ = taxaIQ.Where(s => s.Genus.Family.CategoryID.Contains(CategoryFilter));
            }

            switch (sortOrder) {
                case "species_desc":
                    taxaIQ = taxaIQ.OrderByDescending(s => s.SpecificEpithet);
                    break;

                case "genus":
                    taxaIQ = taxaIQ.OrderBy(s => s.Genus);
                    break;

                case "genus_desc":
                    taxaIQ = taxaIQ.OrderByDescending(s => s.Genus);
                    break;

                default: 
                    taxaIQ = taxaIQ.OrderBy(s => s.SpecificEpithet);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 10);
            Taxa = await PaginatedList<csci340_iseegreen.Models.Taxa>.CreateAsync(
            taxaIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            

        }
    }
}
