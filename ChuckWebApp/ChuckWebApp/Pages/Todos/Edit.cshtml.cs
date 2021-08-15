using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChuckWebApp.Data;
using ChuckWebApp.Areas.Identity.Data;
using ChuckWebApp.Models;

namespace ChuckWebApp.Pages.Todos
{
    public class EditModel : PageModel
    {
        private readonly ChuckWebAppContext _context;

        public EditModel(ChuckWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _context.Todos.FindAsync(id);

            if (Todo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var studentToUpdate = await _context.Todos.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Todo>(
                studentToUpdate,
                "todo",
                s => s.Activity, s => s.DueDate, s => s.IsDone))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Todos.Any(e => e.TodoID == id);
        }
    }
}
