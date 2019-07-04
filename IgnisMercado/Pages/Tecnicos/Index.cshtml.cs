using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Pages.Tecnicos
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> Tecnico { get;set; }

        public async Task OnGetAsync()
        {
            Tecnico = await _context.Tecnicos.ToListAsync();
        }
    }
}
