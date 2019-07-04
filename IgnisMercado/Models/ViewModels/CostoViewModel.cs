namespace IgnisMercado.Models.ViewModels
{
    public class CostoViewModel
    {
        public CostoViewModel()
        {
            this.PrimeraHoraBasico=0;
            this.CostoHoraBasico=0;
            this.JornadaBasico=0;
            this.PrimeraHoraAvanzado=0;
            this.CostoHoraAvanzado=0;
            this.JornadaAvanzado=0;
            this.HoraJornada=0;
        }
        
        public int Id { get; set; }

        public int PrimeraHoraBasico { get; set; }

        public int CostoHoraBasico { get; set; }

        public int JornadaBasico { get; set; }

        public int PrimeraHoraAvanzado { get; set; }

        public int CostoHoraAvanzado { get; set; }
        
        public int JornadaAvanzado { get; set; }

        public int HoraJornada { get; set; }
    }
}
