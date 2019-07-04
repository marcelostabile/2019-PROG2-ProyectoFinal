using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.Tecnicos
{
    public class CreateModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public CreateModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tecnico Tecnico { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tecnicos.Add(Tecnico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}