using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using IgnisMercado.Models;

namespace IgnisMercado.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime DOB { get; set; }

        // Es necesario tener acceso a IdentityManager para poder buscar el rol de este usuario; esta propiedad se asigna cada vez que se
        // cambia el rol usando IdentityManager para poder buscar por rol después cuando no hay acceso a IdentityManager. La propiedad
        // puede ser null para los usuarios que todavía no tienen un rol asignado.

        [Required]
        [Display(Name = "Perfil")]
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
        /// El Status permite al Administrador de Ignis habilitar/deshabilitar las operaciones de un usuario.
        /// </summary>
        [Display(Name = "Status")]
        public bool Status { get; private set; }

        /// <summary>
        /// Métodos para cambiar el status.
        /// </summary>
        public void StatusHabilitar() 
        {
            this.Status = true;
        }

        public void StatusInhabilitar() 
        {
            this.Status = false;
        }

    }
}
