using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Models.AsientoModels
{
    public class AsientoUpdateModel : AsientoBaseModel
    {
        public AsientoUpdateModel() { }

        public void UpdateEntity(Asiento asiento)
        {
            asiento.IdBus = this.IdBus;
            asiento.NumeroPiso = this.NumeroPiso;
            asiento.NumeroAsiento = this.NumeroAsiento;
            asiento.FechaCreacion = this.FechaCreacion;
        }
    }
}

