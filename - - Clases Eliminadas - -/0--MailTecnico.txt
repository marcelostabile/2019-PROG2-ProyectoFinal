using System;
using System.IO;

namespace Ignis{
   class MailTecnico : Mail
    {
       private string Encabezado;
       
       public MailTecnico(string asunto,Tecnico tecnico,Persona persona, string contenido, string Cuerpo) : base (asunto,contenido)
       {
           this.Remitente = persona;
           this.Destinatario = tecnico;
           this.Asunto = asunto; 
           Encabezado = "Este es un ejemplo"+ tecnico.Nombre;
           this.Contenido = contenido + Encabezado + Cuerpo;
       } 
       
    }
}