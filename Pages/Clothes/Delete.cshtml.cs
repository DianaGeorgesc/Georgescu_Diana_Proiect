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
    public class DeleteModel : PageModel
    {
        private readonly Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext _context;

        public DeleteModel(Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext context)
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

            Cloth = await _context.Cloth.FirstOrDefaultAsync(m => m.ID == id);

            if (Cloth == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cloth = await _context.Cloth.FindAsync(id);

            if (Cloth != null)
            {
                _context.Cloth.Remove(Cloth);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
