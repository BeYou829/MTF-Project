using MTZProject.Interfaces;
using MTZProject.Models;
using System.Runtime.CompilerServices;

namespace MTZProject.Logic
{
    public class Operations : IOperation
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

            //Potencia Requerida

            double fuerzaGravitacional = ((Convert.ToDouble(dataModel.MasaVehiculo) + Convert.ToDouble(dataModel.MasaCarga))
                * Gravedad * Math.Sin(Convert.ToDouble(dataModel.AnguloInclinacion)));

            var potenciaRequerida = ((fuerzaGravitacional * Convert.ToDouble(dataModel.DistanciaDesplazamiento))
                / Convert.ToDouble(dataModel.TiempoCompletar))/745.7;


            // Revoluciones requeridas

            double revolucionesRequeridas = (potenciaRequerida / Convert.ToDouble(dataModel.MaxPotenciaMotor))
                * Convert.ToDouble(dataModel.MaxRpm);


            // Combustible Requerido

            double combustibleRequerido = (revolucionesRequeridas * Convert.ToDouble(dataModel.ConsumoCombustible))/1000;

            if (!(revolucionesRequeridas > Convert.ToDouble(dataModel.MaxRpm) && combustibleRequerido > Convert.ToDouble(dataModel.NivelCombustible))){
               
            }
            
        }
    }
}
