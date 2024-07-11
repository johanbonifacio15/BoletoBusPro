using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Application.Dtos.BusDto;

namespace BoletoBusPro.Module.Application.Extensions
{
    public static class BusDtoExtensions
    {
        public static Bus ToEntity(this BusDtoAdd busDto)
        {
            return new Bus
            {
                NumeroPlaca = busDto.NumeroPlaca,
                Nombre = busDto.Nombre,
                CapacidadPiso1 = busDto.CapacidadPiso1,
                CapacidadPiso2 = busDto.CapacidadPiso2,
                Disponible = busDto.Disponible,
                FechaCreacion = DateTime.Now,
            };
        }

        public static void UpdateEntity(this BusDtoUpdate busDto, Bus bus)
        {
            bus.NumeroPlaca = busDto.NumeroPlaca;
            bus.Nombre = busDto.Nombre;
            bus.CapacidadPiso1 = busDto.CapacidadPiso1;
            bus.CapacidadPiso2 = busDto.CapacidadPiso2;
            bus.Disponible = busDto.Disponible;
        }
    }
}

