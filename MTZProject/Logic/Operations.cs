using MTZProject.Models;
using System.Runtime.CompilerServices;

namespace MTZProject.Logic
{
    public class Operations
    {
        private static readonly double Gravedad = 9.81d;
        public static void Processing(InputProcessVM dataModel)
        {
            double pesoNetoVehiculo = ((Convert.ToDouble(dataModel.MasaVehiculo) * Gravedad));
            double pesoCarga = (Convert.ToDouble(dataModel.MasaCarga) * Gravedad);
            double pesoTotalVehiculo = (pesoNetoVehiculo + pesoCarga);
            double velocidad = (Convert.ToDouble(dataModel.DistanciaDesplazamiento) / Convert.ToDouble(dataModel.TiempoCompletar));
            double aceleracion = (velocidad / Convert.ToDouble(dataModel.TiempoCompletar));
            double fuerzaAtraccion = (pesoTotalVehiculo * Math.Sin(Convert.ToDouble(dataModel.AnguloInclinacion)));
            double fuerzaNeta = (
                aceleracion * Math.Sin(Convert.ToDouble(dataModel.AnguloInclinacion)
                * (Convert.ToDouble(dataModel.MasaVehiculo) + Convert.ToDouble(dataModel.MasaCarga)))
                );
            double fuerzaRequeridaImpluso = (fuerzaAtraccion + fuerzaNeta);

            var potenciaRequerida = 0;
        }
    }
}
