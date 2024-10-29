using System.Reflection.Metadata.Ecma335;

namespace MTZProject.Models
{
    public class OutputProcessVM
    {
        public bool Posible { get; set; }
        public double PesoNetoVehiculo { get; set; }
        public double PesoCarga { get; set; }
        public double PesoTotalVehiculo { get; set; }
        public double Velocidad { get; set; }
        public double Aceleracion { get; set; }
        public double FuerzaAtraccion { get; set; }
        public double FuerzaNeta { get; set; }
        public double FuerzaRequeridaImpulso { get; set; }
        public double PotenciaRequerida { get; set; }
        public double RevolucionesRequeridas { get; set; }
        public double CombustibleRequerido { get; set; }
    }
}
