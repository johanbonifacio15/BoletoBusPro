using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Domain.Models.BusModels;

namespace BoletoBusPro.Module.Domain.Models.BusModels
{
    public class BusModel : BusBaseModel
    {
        public BusModel() { }

        public static BusModel FromEntity(Bus bus)
        {
            return new BusModel
            {
                IdBus = bus.Id,
                NumeroPlaca = bus.NumeroPlaca,
                Nombre = bus.Nombre,
                CapacidadPiso1 = bus.CapacidadPiso1,
                CapacidadPiso2 = bus.CapacidadPiso2,
                CapacidadTotal = bus.CapacidadTotal,
                Disponible = bus.Disponible,
                FechaCreacion = bus.FechaCreacion
            };
        }
    }
}

