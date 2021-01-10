using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Georgescu_Diana_Proiect.Data;

namespace Georgescu_Diana_Proiect.Models
{
    public class ClothCategoriesPageModel : PageModel
    {
        public List<AssignedClothCategoryData> AssignedClothCategoryDataList;
        public void PopulateAssignedClothCategoryData(Georgescu_Diana_ProiectContext context,
        Cloth cloth)
        {
            var allCategories = context.Category;
            var clothCategories = new HashSet<int>(
            cloth.ClothCategories.Select(c => c.ClothID));
            AssignedClothCategoryDataList = new List<AssignedClothCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedClothCategoryDataList.Add(new AssignedClothCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = clothCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateClothCategories(Georgescu_Diana_ProiectContext context,
 string[] selectedCategories, Cloth clothToUpdate)
        {
            if (selectedCategories == null)
            {
                clothToUpdate.ClothCategories = new List<ClothCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var clothCategories = new HashSet<int>
            (clothToUpdate.ClothCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!clothCategories.Contains(cat.ID))
                    {
                        clothToUpdate.ClothCategories.Add(
                        new ClothCategory
                        {
                            ClothID = clothToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (clothCategories.Contains(cat.ID))
                    {
                        ClothCategory courseToRemove
                        = clothToUpdate
                        .ClothCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }

            }
        }
    }
}

