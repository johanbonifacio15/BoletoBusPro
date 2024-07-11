using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Application.Dtos.AsientoDto;

namespace BoletoBusPro.Module.Application.Extensions
{
    public static class AsientoDtoExtensions
    {
        public static Asiento ToEntity(this AsientoDtoAdd asientoDto)
        {
            return new Asiento
            {
                IdBus = asientoDto.IdBus,
                NumeroPiso = asientoDto.NumeroPiso,
                NumeroAsiento = asientoDto.NumeroAsiento
            };
        }

        public static void UpdateEntity(this AsientoDtoUpdate asientoDto, Asiento asiento)
        {
            asiento.IdBus = asientoDto.IdBus;
            asiento.NumeroPiso = asientoDto.NumeroPiso;
            asiento.NumeroAsiento = asientoDto.NumeroAsiento;
        }
    }
}



