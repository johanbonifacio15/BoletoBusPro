namespace BoletoBusPro.Module.Application.Dtos.AsientoDto
{
    public record AsientoDtoGet(
        int IdAsiento,
        int IdBus,
        int NumeroPiso,
        int NumeroAsiento,
        DateTime FechaCreacion
    );
}

