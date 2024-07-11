namespace BoletoBusPro.Module.Application.Dtos.BusDto
{
    public record BusDtoUpdate(
        int IdBus,
        string NumeroPlaca,
        string Nombre,
        int CapacidadPiso1,
        int CapacidadPiso2,
        bool Disponible,
        DateTime FechaCreacion
    );
}

