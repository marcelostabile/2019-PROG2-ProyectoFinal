using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.roles
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.IgnisContext _context;

        public IndexModel(RazorPagesIgnis.Models.IgnisContext context)
        {
            _context = context;
        }

        public IList<Rol> Rol { get;set; }

        public async Task OnGetAsync()
        {
            Rol = await _context.Roles.ToListAsync();
        }
    }
}
