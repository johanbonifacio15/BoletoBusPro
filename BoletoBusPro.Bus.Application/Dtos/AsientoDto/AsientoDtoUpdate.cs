namespace BoletoBusPro.Module.Application.Dtos.AsientoDto
{
    public record AsientoDtoUpdate(
        int IdAsiento,
        int IdBus,
        int NumeroPiso,
        int NumeroAsiento
    );
}
