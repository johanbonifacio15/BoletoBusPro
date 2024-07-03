using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Domain.Models.BusModels;

namespace BoletoBusPro.Module.Persistence.Models.BusModels
{
    public class BusSaveModel : BusBaseModel
    {
        public BusSaveModel()
        {
        }

        public Bus ToEntity()
        {
            return new Bus
            {
                Id = this.IdBus,
                NumeroPlaca = this.NumeroPlaca,
                Nombre = this.Nombre,
                CapacidadPiso1 = this.CapacidadPiso1,
                CapacidadPiso2 = this.CapacidadPiso2,
                CapacidadTotal = this.CapacidadTotal,
                Disponible = this.Disponible,
                FechaCreacion = this.FechaCreacion
            };
        }
    }
}
