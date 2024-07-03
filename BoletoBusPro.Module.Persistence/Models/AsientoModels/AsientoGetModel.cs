using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Models.AsientoModels
{
    public class AsientoGetModel : AsientoBaseModel
    {
        public static AsientoGetModel FromEntity(Asiento asiento)
        {
            return new AsientoGetModel
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

