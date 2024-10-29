using MTZProject.Interfaces;
using MTZProject.Models;
using System.Runtime.CompilerServices;

namespace MTZProject.Logic
{
    public class Operations : IOperation
    {
        private static readonly double Gravedad = 9.81d;
        public static OutputProcessVM Processing(InputProcessVM dataModel)
        {
            var output = new OutputProcessVM();
            
            double pesoNetoVehiculo = ((Convert.ToDouble(dataModel.MasaVehiculo) * Gravedad));
            double pesoCarga = (Convert.ToDouble(dataModel.MasaCarga) * Gravedad);
            double pesoTotalVehiculo = (pesoNetoVehiculo + pesoCarga);
            double velocidad = (Convert.ToDouble(dataModel.DistanciaDesplazamiento) / Convert.ToDouble(dataModel.TiempoCompletar));
            double aceleracion = (velocidad / Convert.ToDouble(dataModel.TiempoCompletar));
            double fuerzaAtraccion = (pesoTotalVehiculo * Math.Sin(((Convert.ToDouble(dataModel.AnguloInclinacion) * Math.PI) / 180)));

            double fuerzaAceleracion = ((Convert.ToDouble(dataModel.MasaVehiculo) + Convert.ToDouble(dataModel.MasaCarga)) * aceleracion);

            var anRad = Math.Sin(((Convert.ToDouble(dataModel.AnguloInclinacion) * Math.PI) / 180));
            double fuerzaNeta = ( aceleracion * anRad * (Convert.ToDouble(dataModel.MasaVehiculo) + Convert.ToDouble(dataModel.MasaCarga)) );


            double fuerzaRequeridaImpluso = (fuerzaNeta - fuerzaAtraccion);

            //Potencia Requerida

            //double fuerzaGravitacional = ((Convert.ToDouble(dataModel.MasaVehiculo) + Convert.ToDouble(dataModel.MasaCarga))
            //    * Gravedad * Math.Sin(((Convert.ToDouble(dataModel.AnguloInclinacion) * Math.PI) / 180)));

            var potenciaRequerida = (((Math.Abs(fuerzaRequeridaImpluso)) * Convert.ToDouble(dataModel.DistanciaDesplazamiento))
                / Convert.ToDouble(dataModel.TiempoCompletar))/745.7;


            // Revoluciones requeridas

            double revolucionesRequeridas = (potenciaRequerida * 745.7)
                / Convert.ToDouble(dataModel.MaxRpm);


            // Combustible Requerido

            double combustibleRequerido = ((Math.Abs(fuerzaRequeridaImpluso) * Convert.ToDouble(dataModel.DistanciaDesplazamiento)) * Convert.ToDouble(dataModel.ConsumoCombustible))/1000;

           

            output.PesoNetoVehiculo = pesoNetoVehiculo;
            output.PesoCarga = pesoCarga;
            output.PesoTotalVehiculo = pesoTotalVehiculo;
            output.Velocidad = velocidad;
            output.Aceleracion = aceleracion;
            output.FuerzaAtraccion = fuerzaAtraccion;
            output.FuerzaNeta = fuerzaNeta;
            output.FuerzaRequeridaImpulso = fuerzaRequeridaImpluso;
            output.PotenciaRequerida = potenciaRequerida;
            output.RevolucionesRequeridas = revolucionesRequeridas;
            output.CombustibleRequerido = combustibleRequerido;

            if (!(potenciaRequerida < Convert.ToDouble(dataModel.MaxPotenciaMotor) && combustibleRequerido < Convert.ToDouble(dataModel.NivelCombustible)))
            {
                output.Posible = false;
                return output;
            }
            output.Posible = true;
            return output;
        }
    }
}
