using BoletoBusPro.Module.Application.Core;
using BoletoBusPro.Module.Application.Dtos.BusDto;
using BoletoBusPro.Module.Persistence.Models.BusModels;

namespace BoletoBusPro.Module.Application.Interfaces
{
    public interface IBusService 
    {
        ServiceResult GetBuses();
        ServiceResult GetBus(int id);
        ServiceResult UpdateBuses(BusDtoUpdate busUpdate);
        ServiceResult RemoveBuses(BusDtoRemove busRemove);
        ServiceResult SaveBus(BusDtoAdd busAdd);
    }
}

