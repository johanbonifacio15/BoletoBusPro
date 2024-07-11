namespace BoletoBusPro.Module.Application.Dtos.BusDto
{
    public record BusDtoGet(
        int IdBus,
        string NumeroPlaca,
        string Nombre,
        int CapacidadPiso1,
        int CapacidadPiso2,
        int CapacidadTotal,
        bool Disponible,
        DateTime FechaCreacion
    );
}

