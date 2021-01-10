using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Georgescu_Diana_Proiect.Data;
using Georgescu_Diana_Proiect.Models;

namespace Georgescu_Diana_Proiect.Pages.Clothes
{
    public class EditModel :  ClothCategoriesPageModel
    {
        private readonly Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext _context;

        public EditModel(Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cloth Cloth { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cloth= await _context.Cloth
  .Include(b => b.Size)
  .Include(b => b.ClothCategories).ThenInclude(b => b.Category)
  .AsNoTracking()
  .FirstOrDefaultAsync(m => m.ID == id);

            if (Cloth == null)
            {
                return NotFound();
            }
            PopulateAssignedClothCategoryData(_context, Cloth);
            ViewData["SizeID"] = new SelectList(_context.Set<Size>(), "ID", "SizeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothToUpdate = await _context.Cloth
            .Include(i => i.Size)
            .Include(i => i.ClothCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (clothToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Cloth>(
            clothToUpdate,
            "Cloth",
            i => i.ClothingItem,
            i => i.Price, i => i.SaleDate, i => i.Size))
            {
                UpdateClothCategories(_context, selectedCategories, clothToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateClothCategories(_context, selectedCategories, clothToUpdate);
            PopulateAssignedClothCategoryData(_context, clothToUpdate);
            return Page();
        }
    }

}

