using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using IgnisMercado.Models;

namespace IgnisMercado.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        // Es necesario tener acceso a IdentityManager para poder buscar el rol de este usuario; esta propiedad se asigna cada vez que se
        // cambia el rol usando IdentityManager para poder buscar por rol después cuando no hay acceso a IdentityManager. La propiedad
        // puede ser null para los usuarios que todavía no tienen un rol asignado.

        public string Role { get; private set; }

        // El IdentityManager que se recibe como argumento no se usa en el método; sólo fuera a que el rol del usuario sea cambiado cuando
        // existe en el contexto una instancia válida de IdentityManager.
        
        public void AssignRole(UserManager<ApplicationUser> identityManager, string role)
        {
            if (identityManager == null)
            {
                throw new ArgumentNullException("identityManager");
            }

            this.Role = role;
        }

        /// <summary>
        /// El Status de un usuario permite al Administrador de Ignis habilitar/deshabilitar 
        /// las operaciones en la aplicación. Por ejemplo, un técnico con Status = Inactivo 
        /// puede ingresar y consultar históricos pero no puede ser asignado a proyectos.
        /// 
        /// Durante la creación del objeto Cliente, Tecnico o Administrador, Status se inicializa con valor 'Activo'.
        /// </summary>
        /// <returns>True = usuario activo; False = usuario inactivo</returns>
        private bool status;
        public bool Status 
        {
            get => this.status; 
            protected set {}
        }

        /// <summary>
        /// Métodos para cambiar el status, 
        /// Activar(): si el usuario está 'Inactivo' se cambia para 'Activo'.
        /// Inactivar(): si el usuario está 'Activo' se cambia para 'Inactivo'.
        /// </summary>
        public void Activar() 
        {
            if (this.status == false) this.CambiarStatus();
        }

        public void Inactivar() 
        {
            if (this.status == true) this.CambiarStatus();
        }

        private void CambiarStatus() 
        {
            this.status = !this.status;
        }

    }
}
