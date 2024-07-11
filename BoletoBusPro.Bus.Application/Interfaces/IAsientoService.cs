using BoletoBusPro.Module.Domain.Models.AsientoModels;
using BoletoBusPro.Module.Application.Core;
using BoletoBusPro.Module.Application.Dtos.AsientoDto;

namespace BoletoBusPro.Module.Application.Interfaces
{
    public interface IAsientoService
    {
        ServiceResult GetAsientos();
        ServiceResult GetAsiento(int id);
        ServiceResult UpdateAsiento(AsientoDtoUpdate asientoUpdate);
        ServiceResult RemoveAsiento(AsientoDtoRemove asientoRemove);
        ServiceResult SaveAsiento(AsientoDtoAdd asientoAdd);
    }
}

