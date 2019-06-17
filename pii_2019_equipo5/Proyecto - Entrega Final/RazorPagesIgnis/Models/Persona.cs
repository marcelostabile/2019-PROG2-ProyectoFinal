using System;

namespace RazorPagesIgnis 
{   
    public class Persona
    { 
        /// <summary>
        /// La clase Persona es superclase de las clases: Cliente, Técnico y Administrador.
        /// </summary>
        public Persona(string Nombre, string Correo, string Contrasena) 
        { 
            Check.Precondicion(!string.IsNullOrEmpty(Nombre), "Nombre no puede ser nulo o vacío.");
            Check.Precondicion(validaEmail.EsUnEmailValido(Correo), "Formato de correo incorrecto.");
            Check.Precondicion(validaClave.EsUnaContrasenaValida(Contrasena), "La contraseña no cumple los requerimientos necesarios.");

            this.nombre = Nombre;
            this.correo = Correo;
            this.contrasena = Contrasena;
            this.status = true;

            Check.Postcondicion(!string.IsNullOrEmpty(this.nombre), "El nombre es nulo o vacío.");
            Check.Postcondicion(this.status=true, "El status asignado no corresponde al estado activo.");
        }

        IValidarEmail validaEmail = new ValidarEmail();

        IValidarContrasena validaClave = new ValidarContrasena();

        /// <summary>
        /// Nombre del usuario.
        /// 
        /// No se permite un valor nulo o vacío.
        /// </summary>
        private string nombre; 
        public string Nombre  
        {
            get { return this.nombre; }
            set { 
                Check.Precondicion(!string.IsNullOrEmpty(value), "Nombre no puede ser nulo o vacío.");

                this.nombre = value;

                Check.Postcondicion(this.nombre == value, "Nombre no fue actualizado.");
                }
        }

        /// <summary>
        /// Dirección de correo electrónico.
        /// 
        /// La información ingresada debe tener formato de dirección de correo electrónico.
        /// </summary>
        private string correo;
        public string Correo 
        {
            get { return this.correo; }
            set { 
                Check.Precondicion(validaEmail.EsUnEmailValido(value), "Formato de correo incorrecto.");

                this.correo = value; 

                Check.Postcondicion(this.correo == value, "Dirección de correo no fue actualizado.");
                }
        }

        /// <summary>
        /// Contraseña del usuario.
        /// 
        /// Debe cumplir con las condiciones detalladas en la clase EsUnaContrasenaValida (archivo ValidarContrasena.cs)
        /// </summary>
        private string contrasena;
        public string Contrasena  
        {
            get { return this.contrasena; }
            set { 
                Check.Precondicion(validaClave.EsUnaContrasenaValida(value), "La contraseña no cumple los requerimientos necesarios.");

                this.contrasena = value; 

                Check.Postcondicion(this.contrasena == value, "Contraseña no fue actualizada.");
                }
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

        /// Para RazorPages: constructor sin argumentos, atributo ID es PrimaryKey para la base.
        public Persona() 
        {
        }

        public int ID { get; set; }   

    }
}
