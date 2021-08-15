using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChuckWebApp.Data;
using ChuckWebApp.Areas.Identity.Data;
using ChuckWebApp.Models;

namespace ChuckWebApp.Pages.Todos
{
    public class DetailsModel : PageModel
    {
        private readonly ChuckWebAppContext _context;

        public DetailsModel(ChuckWebAppContext context)
        {
            _context = context;
        }

        public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _context.Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TodoID == id);

            if (Todo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
