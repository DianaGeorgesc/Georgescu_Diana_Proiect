using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Georgescu_Diana_Proiect.Data;
using Georgescu_Diana_Proiect.Models;

namespace Georgescu_Diana_Proiect.Pages.Clothes
{
    public class IndexModel : PageModel
    {
        private readonly Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext _context;

        public IndexModel(Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Cloth> Cloth { get;set; }
        public ClothData ClothD { get; set; }
        public int ClothID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ClothD = new ClothData();

            ClothD.Clothes = await _context.Cloth
            .Include(b => b.Size)
            .Include(b => b.ClothCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.ClothingItem)
            .ToListAsync();
            if (id != null)
            {
                ClothID = id.Value;
                Cloth cloth = ClothD.Clothes
                .Where(i => i.ID == id.Value).Single();
                ClothD.Categories = cloth.ClothCategories.Select(s => s.Category);
            }
        }

    }
}
