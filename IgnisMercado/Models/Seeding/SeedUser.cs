using System;
using IgnisMercado.Models;

namespace IgnisMercado.Models.Seeding 
{
    public class SeedUser 
    {
        public string UserName { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

    }
}
