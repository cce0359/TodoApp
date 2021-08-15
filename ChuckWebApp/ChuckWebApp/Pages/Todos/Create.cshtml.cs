using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChuckWebApp.Data;
using ChuckWebApp.Models;
using Microsoft.AspNetCore.Identity;
using ChuckWebApp.Areas.Identity.Data;

namespace ChuckWebApp.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private readonly ChuckWebAppContext _context;
        private  readonly UserManager<ChuckWebAppUser> _userManager;

        public CreateModel(ChuckWebAppContext context, UserManager<ChuckWebAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //ViewData["Message"] = "Create";
            var emptyTodo = new Todo();

            if (await TryUpdateModelAsync<Todo>(
                emptyTodo,
                "todo",   // Prefix for form value.
                t => t.Activity, t => t.DueDate)) //, t => t.ChuckWebAppUserId))
            {
                emptyTodo.ChuckWebAppUserId = _userManager.GetUserId(User).ToString();
                _context.Todos.Add(emptyTodo);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}


/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChuckWebApp.Data;
using ChuckWebApp.Areas.Identity.Data;
using ChuckWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ChuckWebApp.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private readonly ChuckWebAppContext _context;
        private UserManager<ChuckWebAppUser> _userManager;

        public CreateModel(ChuckWebAppContext context, UserManager<ChuckWebAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTodo = new Todo();

            if (await TryUpdateModelAsync<Todo>(
                emptyTodo,
                "",   // Prefix for form value.
                t => t.Activity, t => t.DueDate))
            {
                //string tdid = _userManager.GetUserId(User);
                emptyTodo.ChuckWebAppUserId = _userManager.GetUserId(User);

                _context.Todos.Add(emptyTodo);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
*/
