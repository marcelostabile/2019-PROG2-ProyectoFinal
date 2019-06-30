using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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

        [Required]
        [Display(Name = "Perfil")]
        public string Role { get; private set; }

        /// <summary>
        /// Relación Cliente:Proyectos.
        /// </summary>
        public IList<RelacionClienteProyecto> RelacionClienteProyecto { get; set; }
        
        /// <summary>
        /// Asigna rol al usuario.
        /// </summary>
        public void AssignRole(UserManager<ApplicationUser> identityManager, string role)
        {
            if (identityManager == null)
            {
                throw new ArgumentNullException("identityManager");
            }
            this.Role = role;
        }

        /// <summary>
        /// El Status habilita/deshabilita las operaciones de un usuario.
        /// </summary>
        [Display(Name = "Status")]
        public bool Status { get; private set; }

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
