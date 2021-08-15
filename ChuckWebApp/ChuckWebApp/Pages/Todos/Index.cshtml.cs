using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ChuckWebApp.Data;
using ChuckWebApp.Areas.Identity.Data;
using ChuckWebApp.Pages;
using ChuckWebApp.Models;

namespace ChuckWebApp.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly ChuckWebAppContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ChuckWebAppContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Todo> Todos { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Todo> todosIQ = from t in _context.Todos
                                             select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                todosIQ = todosIQ.Where(t => t.Activity.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    todosIQ = todosIQ.OrderByDescending(t => t.Activity);
                    break;
                case "Date":
                    todosIQ = todosIQ.OrderBy(t => t.DueDate);
                    break;
                case "date_desc":
                    todosIQ = todosIQ.OrderByDescending(t => t.DueDate);
                    break;
                default:
                    todosIQ = todosIQ.OrderBy(t => t.Activity);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Todos = await PaginatedList<Todo>.CreateAsync(
                todosIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
