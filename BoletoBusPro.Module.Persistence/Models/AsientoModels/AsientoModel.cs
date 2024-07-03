using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Models.AsientoModels
{
    public class AsientoModel : AsientoBaseModel
    {
        public AsientoModel() { }

        public static AsientoModel FromEntity(Asiento asiento)
        {
            return new AsientoModel
            {
                IdAsiento = asiento.Id,
                IdBus = asiento.IdBus,
                NumeroPiso = asiento.NumeroPiso,
                NumeroAsiento = asiento.NumeroAsiento,
                FechaCreacion = asiento.FechaCreacion
            };
        }
    }
}

