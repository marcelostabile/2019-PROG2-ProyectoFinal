namespace IgnisMercado.Models 
{
    public interface ICosto 
    {
        int CalcularCostoSolicitud(int modoDeContrato, int horasContratadas, string nivelExperiencia);
    }
    
}