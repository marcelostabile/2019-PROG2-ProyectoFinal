using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IgnisMercado.Areas.Identity.Data
{
    /// <summary>
    /// Inicializa la base de datos de identity.
    /// </summary>
    public static class SeedIdentityData
    {
        /// <summary>
        /// Usuarios y roles necesarios para el funcionamiento de la aplicación.
        /// </summary>
        /// <param name="serviceProvider">El <see cref="IServiceProvider"/> al que se han injectado previamente un
        /// <see cref="UserManager<T>"/> y un <see cref="RoleManager<T>"/>.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            // Verificación de existencia. 

            // Administrador.
            if (userManager.FindByNameAsync(IdentityData.AdminUserName).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = IdentityData.AdminName;
                user.UserName = IdentityData.AdminUserName;
                user.Email = IdentityData.AdminMail;
                user.DOB = IdentityData.AdminDOB;
                user.StatusHabilitar();

                user.AssignRole(userManager, IdentityData.AdminRoleName);

                IdentityResult result = userManager.CreateAsync(user, IdentityData.AdminPassword).Result;

                AddToRole(userManager, result, user, "Admin");
            }

            // Cliente.
            if (userManager.FindByNameAsync(IdentityData.ClientUserName).Result == null)
            {
                ApplicationUser userClient = new ApplicationUser();

                userClient.Name = IdentityData.ClientName;
                userClient.UserName = IdentityData.ClientUserName;
                userClient.Email = IdentityData.ClientMail;
                userClient.DOB = IdentityData.ClientDOB;
                userClient.StatusHabilitar();

                userClient.AssignRole(userManager, IdentityData.NonAdminRoleNames[0]);

                IdentityResult result2 = userManager.CreateAsync(userClient, IdentityData.ClientPassword).Result;

                AddToRole(userManager, result2, userClient, "Cliente");
            }

            // Técnico.
            if (userManager.FindByNameAsync(IdentityData.TechUserName).Result == null)
            {
                ApplicationUser userTechnician = new ApplicationUser();

                userTechnician.Name = IdentityData.TechName;
                userTechnician.UserName = IdentityData.TechUserName;
                userTechnician.Email = IdentityData.TechMail;
                userTechnician.DOB = IdentityData.TechDOB;
                userTechnician.StatusHabilitar();

                userTechnician.AssignRole(userManager, IdentityData.NonAdminRoleNames[1]);

                IdentityResult result3 = userManager.CreateAsync(userTechnician, IdentityData.TechPassword).Result;

                AddToRole(userManager, result3, userTechnician, "Tecnico");
            }
        }

        // Role.
        private static void AddToRole(UserManager<ApplicationUser> userManager, IdentityResult result, ApplicationUser user, string userType) 
        {
            string IdentityDataRole = "";

            string IdentityDataName = "";

            if (result.Succeeded)
            {
                // Tipo de usuario.
                if (userType == "Admin") 
                {
                    IdentityDataName = IdentityData.AdminName;
                    IdentityDataRole = IdentityData.AdminRoleName;
                }
                else if (userType == "Cliente") 
                {
                    IdentityDataName = IdentityData.ClientName;
                    IdentityDataRole = IdentityData.NonAdminRoleNames[0];
                }
                else if (userType == "Tecnico") 
                {
                    IdentityDataName = IdentityData.TechName;
                    IdentityDataRole = IdentityData.NonAdminRoleNames[1];
                }

                IdentityResult addRoleResult = userManager.AddToRoleAsync(user, IdentityDataRole).Result;

                if (!addRoleResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Unexpected error ocurred adding role '{IdentityDataRole}' to user '{IdentityDataName}'.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Unexpected error ocurred creating user '{IdentityDataName}'.");
            }
        }

        // Crear un Role.
        private static void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                IdentityRole role = new IdentityRole(roleName);

                IdentityResult createRoleResult = roleManager.CreateAsync(role).Result;

                if (!createRoleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error ocurred creating role '{role}'.");
                }
            }
        }

        // Crear un Role para Administrador.
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            CreateRole(roleManager, IdentityData.AdminRoleName);

            foreach (var roleName in IdentityData.NonAdminRoleNames)
            {
                CreateRole(roleManager, roleName);
            }
        }
    }
}
