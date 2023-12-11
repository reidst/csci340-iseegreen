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

        public async Task OnGetAsync(int? itemid)
        {
            if (_context.ListItems != null)
            {
                var listQ = from l in _context.ListItems select l;

                if (itemid != null) {
                    listQ = listQ.Where(l => l.ListID == itemid);
                }

                listQ = listQ.Include(l => l.List)
                .Include(l => l.Location)
                .Include(l => l.Plant);
            
                var list = await listQ.ToListAsync();
                
                ListItems = list;
            }

        }
    }
}
