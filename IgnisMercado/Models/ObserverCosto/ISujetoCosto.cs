using System.Collections.Generic;

namespace IgnisMercado.Models
{
    public abstract class ISujetoCosto 
    {
        private List<IObserverCosto> ListaObservers = new List<IObserverCosto>();
        
        public void Agregar(IObserverCosto observer) 
        {
            ListaObservers.Add(observer);
        }

        public void Eliminar(IObserverCosto observer) 
        { 
            ListaObservers.Remove(observer);
        }

        public void Notificar() 
        {
            foreach (IObserverCosto observer in ListaObservers)
            {
                observer.ActualizarCostoSolicitudActiva();
            }
        }
    }

}
