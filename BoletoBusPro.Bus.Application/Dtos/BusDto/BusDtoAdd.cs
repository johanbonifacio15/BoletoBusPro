namespace BoletoBusPro.Module.Application.Dtos.BusDto
{
    public record BusDtoAdd(
        string NumeroPlaca,
        string Nombre,
        int CapacidadPiso1,
        int CapacidadPiso2,
        bool Disponible,
        DateTime FechaCreacion
    );
}
