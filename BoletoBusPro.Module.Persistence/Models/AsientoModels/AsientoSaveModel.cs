using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Models.AsientoModels
{
    public class AsientoSaveModel : AsientoBaseModel
    {
        public AsientoSaveModel() { }

        public Asiento ToEntity()
        {
            return new Asiento
            {
                Id = this.IdAsiento,
                IdBus = this.IdBus,
                NumeroPiso = this.NumeroPiso,
                NumeroAsiento = this.NumeroAsiento,
                FechaCreacion = this.FechaCreacion
            };
        }
    }
}

