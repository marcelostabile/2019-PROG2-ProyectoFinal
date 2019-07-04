using System;
using IgnisMercado.Models;

namespace IgnisMercado.Models.Seeding 
{
    /// <summary>
    /// Esta clase define los atributos de un usuario durante el seeding que realiza la clase Seeding.
    /// </summary>
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
