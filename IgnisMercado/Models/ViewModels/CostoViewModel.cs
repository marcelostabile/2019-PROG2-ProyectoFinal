using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Models.ViewModels
{
    public class CostoViewModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int PrimeraHoraBasico { get; set; }

        [BindProperty]
        public int CostoHoraBasico { get; set; }

        [BindProperty]
        public int JornadaBasico { get; set; }

        [BindProperty]
        public int PrimeraHoraAvanzado { get; set; }

        [BindProperty]
        public int CostoHoraAvanzado { get; set; }
        
        [BindProperty]
        public int JornadaAvanzado { get; set; }

        [BindProperty]
        public int HoraJornada { get; set; }
    }
}
