namespace IgnisMercado 
{   
    public class Persona
    { 
        /// <summary>
        /// Para RazorPages: constructor sin argumentos.
        /// </summary>
        public Persona() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// La clase Persona es superclase de las clases: Cliente, Técnico y Administrador.
        /// </summary>
        public Persona(string nombre, string correo, string contrasena) 
        { 
            Check.Precondicion(!string.IsNullOrEmpty(nombre), "Nombre no puede ser nulo o vacío.");
            Check.Precondicion(ValidaEmail.EsUnEmailValido(correo), "Formato de correo incorrecto.");
            Check.Precondicion(ValidaClave.EsUnaContrasenaValida(contrasena), "La contraseña no cumple los requerimientos necesarios.");

            this.Nombre = nombre;
            this.Correo = correo;
            this.Contrasena = contrasena;
            this.Status = true;

            Check.Postcondicion(!string.IsNullOrEmpty(this.Nombre), "El nombre es nulo o vacío.");
            Check.Postcondicion(this.Status=true, "El status asignado no corresponde al estado activo.");
        }

        // Instanciamos esta clase para validar el formato de correo.
        IValidarEmail ValidaEmail = new ValidarEmail();

        // Instanciamos esta clase para validar el formato de la contraseña.
        IValidarContrasena ValidaClave = new ValidarContrasena();

        /// <summary>
        /// Nombre del usuario.
        /// 
        /// No se permite un valor nulo o vacío.
        /// </summary>
        private string Nombre; 
        public string nombre  
        {
            get { return this.Nombre; }
            set { 
                Check.Precondicion(!string.IsNullOrEmpty(value), "Nombre no puede ser nulo o vacío.");

                this.Nombre = value;

                Check.Postcondicion(this.Nombre == value, "Nombre no fue actualizado.");
                }
        }

        /// <summary>
        /// Dirección de correo electrónico.
        /// 
        /// La información ingresada debe tener formato de dirección de correo electrónico.
        /// </summary>
        private string Correo;
        public string correo 
        {
            get { return this.Correo; }
            set { 
                Check.Precondicion(ValidaEmail.EsUnEmailValido(value), "Formato de correo incorrecto.");

                this.Correo = value; 

                Check.Postcondicion(this.Correo == value, "Dirección de correo no fue actualizado.");
                }
        }

        /// <summary>
        /// Contraseña del usuario.
        /// 
        /// Debe cumplir con las condiciones detalladas en la clase EsUnaContrasenaValida (archivo ValidarContrasena.cs)
        /// </summary>
        private string Contrasena;
        public string contrasena  
        {
            get { return this.Contrasena; }
            set { 
                Check.Precondicion(ValidaClave.EsUnaContrasenaValida(value), "La contraseña no cumple los requerimientos necesarios.");

                this.Contrasena = value; 

                Check.Postcondicion(this.Contrasena == value, "Contraseña no fue actualizada.");
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
        private bool Status;
        public bool status 
        {
            get => this.Status; 
            protected set {}
        }

        /// <summary>
        /// Métodos para cambiar el status, 
        /// Activar(): si el usuario está 'Inactivo' se cambia para 'Activo'.
        /// Inactivar(): si el usuario está 'Activo' se cambia para 'Inactivo'.
        /// </summary>
        public void Activar() 
        {
            if (this.Status == false) this.CambiarStatus();
        }

        public void Inactivar() 
        {
            if (this.Status == true) this.CambiarStatus();
        }

        private void CambiarStatus() 
        {
            this.Status = !this.Status;
        }

    }
}
