using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Georgescu_Diana_Proiect.Data;
using Georgescu_Diana_Proiect.Models;

namespace Georgescu_Diana_Proiect.Pages.Clothes
{
    public class CreateModel :  ClothCategoriesPageModel
    {
        private readonly Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext _context;

        public CreateModel(Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SizeID"] = new SelectList(_context.Set<Size>(), "ID", "SizeName");
            var cloth = new Cloth();
            cloth.ClothCategories = new List<ClothCategory>();
            PopulateAssignedClothCategoryData(_context, cloth);

            return Page();
        }

        [BindProperty]
        public Cloth Cloth { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCloth = new Cloth();
            if (selectedCategories != null)
            {
                newCloth.ClothCategories = new List<ClothCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ClothCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCloth.ClothCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Cloth>(
            newCloth,
            "Cloth",
            i => i.ClothingItem,
            i => i.Price, i => i.SaleDate, i => i.SizeID))
            {
                _context.Cloth.Add(newCloth);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedClothCategoryData(_context, newCloth);
            return Page();
        }

    }
}
