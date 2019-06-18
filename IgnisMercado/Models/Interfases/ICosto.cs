namespace IgnisMercado.Models 
{
    public interface ICosto 
    {
        int CalcularCostoSolicitud(int ModoDeContrato, int HorasContratadas,string NivelExperiencia);
    }
    
}