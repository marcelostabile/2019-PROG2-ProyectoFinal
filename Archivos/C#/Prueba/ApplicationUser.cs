using System;
using System.ComponentModel.DataAnnotations;

namespace ignis
{

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string Tipo)
        {
            if (Tipo == "Administrador")
            { 
                Administrador Administrador = new Administrador();
            }
            else if (Tipo == "Cliente")
            { 
                Cliente Cliente = new Cliente();
            }
            else
            { 
                Tecnico Tecnico = new Tecnico();
            }
        }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Role { get; private set; }

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
