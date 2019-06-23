using System; 
using System.Collections.Generic;

namespace IgnisMercado.Models.Seeding 
{
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
                UserName = "admin@correo.com",
                Name = "Admin",
                Email = "admin@correo.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = AdminRole
            };

            ListaUsuarios.Add(user1);

            // cliente.
            SeedUser user2 = new SeedUser 
            {
                UserName = "cliente@correo.com",
                Name = "Cliente",
                Email = "cliente@correo.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[0]
            };

            ListaUsuarios.Add(user2);

            // técnico.
            SeedUser user3 = new SeedUser 
            {
                UserName = "tecnico@correo.com",
                Name = "Tecnico",
                Email = "tecnico@correo.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[1]
            };

            ListaUsuarios.Add(user3);

            // cliente 2.
            SeedUser user4 = new SeedUser 
            {
                UserName = "marcelo@correo.com",
                Name = "Marcelo",
                Email = "marcelo@correo.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[0]
            };

            ListaUsuarios.Add(user4);

            // cliente 3.
            SeedUser user5 = new SeedUser 
            {
                UserName = "lucas@correo.com",
                Name = "Lucas",
                Email = "lucas@correo.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[0]
            };

            ListaUsuarios.Add(user5);

            // técnico 2.
            SeedUser user6 = new SeedUser 
            {
                UserName = "pablo@correo.com",
                Name = "Pablo",
                Email = "pablo@correo.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[1]
            };

            ListaUsuarios.Add(user6);

            // técnico 3.
            SeedUser user7 = new SeedUser 
            {
                UserName = "juan@correo.com",
                Name = "Juan",
                Email = "juan@correo.com",
                DOB = new DateTime(1978, 9, 25),
                Password = "Abece.123",
                UserType = NonAdminRole[1]
            };

            ListaUsuarios.Add(user7);

        }
    }
}
