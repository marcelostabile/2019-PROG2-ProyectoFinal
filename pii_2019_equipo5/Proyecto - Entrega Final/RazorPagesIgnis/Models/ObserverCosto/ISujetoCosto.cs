using System;
using System.Collections.Generic;

namespace RazorPagesIgnis 
{
    public abstract class ISujetoCosto 
    {
        private List<IObserverCosto> ListaDeObservers = new List<IObserverCosto>();
        
        public void Agregar(IObserverCosto observer) 
        {
            ListaDeObservers.Add(observer);
        }

        public void Eliminar(IObserverCosto observer) 
        { 
            ListaDeObservers.Remove(observer);
        }

        public void Notificar() 
        {
            foreach (IObserverCosto observer in ListaDeObservers)
            {
                observer.ActualizarCostoSolicitudesActivas();
            }
        }
    }

}
