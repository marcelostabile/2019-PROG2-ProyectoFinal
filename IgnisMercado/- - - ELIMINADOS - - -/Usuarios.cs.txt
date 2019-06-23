// using System.Collections.Generic;

// namespace IgnisMercado.Models 
// {   
//     public class Usuarios : IUsuariosAdministradores, IUsuariosClientes, IUsuariosTecnicos 
//     {
//         /// <summary>
//         /// Esta clase conoce la lista de usuarios y su comportamiento comprende 
//         /// las acciones de agregar y eliminar usuarios de las correspondientes listas.
//         /// </summary>
//         public Usuarios()  
//         {   
//             this.ListaAdministradores = new List<Administrador>();

//             this.ListaClientes = new List<Cliente>();

//             this.ListaTecnicos = new List<Tecnico>();
//         } 

//         /// <summary>
//         /// Lista de Administradores.
//         /// </summary>
//         private List<Administrador> ListaAdministradores;
//         public List<Administrador> listaAdministradores 
//         {
//             get => this.ListaAdministradores;
//             protected set {}
//         }

//         /// <summary>
//         /// Lista de Clientes.
//         /// </summary>
//         private List<Cliente> ListaClientes;
//         public List<Cliente> listaClientes 
//         {
//             get => this.ListaClientes;
//             protected set {}
//         }

//         // Lista de Técnicos.
//         private List<Tecnico> ListaTecnicos;
//         public List<Tecnico> listaDeTecnicos 
//         {
//             get => this.ListaTecnicos;
//             protected set {}
//         }

//         /// <summary>
//         /// Método para agregar un administrador a la lista.
//         /// </summary>
//         /// <param name="AdministradorNuevo"></param>
//         public void AgregarAdministrador(Administrador AdministradorNuevo)  
//         {
//             this.ListaAdministradores.Add(AdministradorNuevo);
//         }

//         /// <summary>
//         /// Método para eliminar un administrador de la lista.
//         /// </summary>
//         /// <param name="AdministradorEliminado"></param>
//         public void EliminarAdministrador(Administrador AdministradorEliminado)  
//         {
//             this.ListaAdministradores.Remove(AdministradorEliminado);
//         }

//         /// <summary>
//         /// Método para agregar un cliente a la lista.
//         /// </summary>
//         /// <param name="ClienteNuevo"></param>
//         public void AgregarCliente(Cliente ClienteNuevo)  
//         {
//             this.ListaClientes.Add(ClienteNuevo);
//         }

//         /// <summary>
//         /// Método para eliminar un cliente de la lista.
//         /// </summary>
//         /// <param name="ClienteEliminado"></param>
//         public void EliminarCliente(Cliente ClienteEliminado)  
//         {
//             this.ListaClientes.Remove(ClienteEliminado);
//         }

//         /// <summary>
//         /// Método para agregar un técnico a la lista.
//         /// </summary>
//         /// <param name="TecnicoNuevo"></param>
//         public void AgregarTecnico(Tecnico TecnicoNuevo)  
//         {
//             this.ListaTecnicos.Add(TecnicoNuevo);
//         }

//         /// <summary>
//         /// Método para eliminar un técnico de la lista.
//         /// </summary>
//         /// <param name="TecnicoEliminado"></param>
//         public void EliminarTecnico(Tecnico TecnicoEliminado)  
//         {
//             this.ListaTecnicos.Remove(TecnicoEliminado);
//         }

//     }
// }