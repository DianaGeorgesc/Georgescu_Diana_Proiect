using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Georgescu_Diana_Proiect.Data;
using Georgescu_Diana_Proiect.Models;

namespace Georgescu_Diana_Proiect.Pages.Sizes
{
    public class DeleteModel : PageModel
    {
        private readonly Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext _context;

        public DeleteModel(Georgescu_Diana_Proiect.Data.Georgescu_Diana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Size Size { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Size = await _context.Size.FirstOrDefaultAsync(m => m.ID == id);

            if (Size == null)
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

            Size = await _context.Size.FindAsync(id);

            if (Size != null)
            {
                _context.Size.Remove(Size);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
