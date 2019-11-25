using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tasker.Pages
{
    public class CreateTaskModel : PageModel
    {
        private ApplicationDbContext _context;

        [BindProperty]
        public Task NewTask { get; set; }

        public CreateTaskModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(NewTask);
                _context.SaveChanges();
                return RedirectToPage("Index");
            } else
            {
                return Page();
            }
        }
    }
}
