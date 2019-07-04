using System; 
using System.Collections.Generic;

namespace IgnisMercado.Models.Seeding 
{
    /// <summary>
    /// Esta clase conoce la información de los usuarios para el seeding.
    /// </summary>
    public class SeedUserData 
    {
        public IList<SeedUser> ListaUsuarios = new List<SeedUser>();

        // Roles
        public const string AdminRole = "Administrador";

        public static string[] NonAdminRole = new string[] { "Cliente", "Técnico" };

        public void CargarListaUsuarios() 
        {
            // administrador.
            SeedUser user1 = new SeedUser 
            {
                UserName = "admin@ignis.com",
                Name = "Admin",
                Email = "admin@ignis.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = AdminRole
            };

            ListaUsuarios.Add(user1);

            // cliente.
            SeedUser user2 = new SeedUser 
            {
                UserName = "cliente@ignis.com",
                Name = "Cliente",
                Email = "cliente@ignis.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[0]
            };

            ListaUsuarios.Add(user2);

            // técnico.
            SeedUser user3 = new SeedUser 
            {
                UserName = "tecnico@ignis.com",
                Name = "Tecnico",
                Email = "tecnico@ignis.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[1]
            };

            ListaUsuarios.Add(user3);

            // cliente 2.
            SeedUser user4 = new SeedUser 
            {
                UserName = "marcelo@ignis.com",
                Name = "Marcelo",
                Email = "marcelo@ignis.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[0]
            };

            ListaUsuarios.Add(user4);

            // cliente 3.
            SeedUser user5 = new SeedUser 
            {
                UserName = "matias@ignis.com",
                Name = "Matias",
                Email = "matias@ignis.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[0]
            };

            ListaUsuarios.Add(user5);

            // técnico 2.
            SeedUser user6 = new SeedUser 
            {
                UserName = "sofia@ignis.com",
                Name = "Sofia",
                Email = "sofia@ignis.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[1]
            };

            ListaUsuarios.Add(user6);

            // técnico 3.
            SeedUser user7 = new SeedUser 
            {
                UserName = "fausto@ignis.com",
                Name = "Fausto",
                Email = "fausto@ignis.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[1]
            };

            ListaUsuarios.Add(user7);

        }
    }
}
