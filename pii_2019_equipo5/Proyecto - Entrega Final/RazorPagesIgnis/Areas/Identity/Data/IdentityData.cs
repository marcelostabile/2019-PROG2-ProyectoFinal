using System;

namespace RazorPagesIgnis.Areas.Identity.Data
{
    public static class IdentityData
    {
        //Administrador

        public const string AdminUserName = "admin@correo.com";

        public const string AdminName = "Admin";

        public const string AdminMail = "admin@correo.com";

        public static DateTime AdminDOB = new DateTime(1978, 9, 25);

        public const string AdminPassword = "Abece.123";

        // Técnico
        public const string TechUserName = "tecnico@correo.com";

        public const string TechName = "Tecnico";

        public const string TechMail = "tecnico@correo.com";

        public static DateTime TechDOB = new DateTime(1978, 9, 25);

        public const string TechPassword = "Abece.123";

        // Cliente
        public const string ClientUserName = "cliente@correo.com";

        public const string ClientName = "Cliente";

        public const string ClientMail = "cliente@correo.com";

        public static DateTime ClientDOB = new DateTime(1978, 9, 25);

        public const string ClientPassword = "Abece.123";

        // Roles
        public const string AdminRoleName = "Administrador";

        public static string[] NonAdminRoleNames = new string[] { "Cliente", "Técnico" };
    }
}
