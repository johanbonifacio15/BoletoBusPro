using BoletoBusPro.Module.Application.Core;
using BoletoBusPro.Module.Application.Dtos.BusDto;
using BoletoBusPro.Module.Application.Extensions;
using BoletoBusPro.Module.Application.Interfaces;
using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoletoBusPro.Module.Application.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository busRepository;
        private readonly ILogger logger;

        public BusService(IBusRepository busRepository, ILogger<BusService> logger)
        {
            this.busRepository = busRepository;
            this.logger = logger;
        }

        private ServiceResult Execute(Func<ServiceResult> action, string errorMessage)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = action();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = errorMessage;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        private ServiceResult Validate(Func<bool> condition, string errorMessage)
        {
            ServiceResult result = new ServiceResult();
            if (condition())
            {
                result.Success = false;
                result.Message = errorMessage;
                return result;
            }
            result.Success = true;
            return result;
        }

        public ServiceResult GetBuses()
        {
            return Execute(() => {
                var buses = busRepository.GetAll();
                var result = new ServiceResult
                {
                    Data = buses.Select(bus => new BusDtoGet(
                        bus.Id,
                        bus.NumeroPlaca,
                        bus.Nombre,
                        bus.CapacidadPiso1,
                        bus.CapacidadPiso2,
                        bus.CapacidadTotal,
                        bus.Disponible,
                        bus.FechaCreacion
                    )).ToList()
                };
                return result;
            }, "Hubo un error durante la obtención de los buses.");
        }

        public ServiceResult GetBus(int id)
        {
            return Execute(() => {
                var bus = busRepository.GetEntityBy(id);
                if (bus == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Bus no encontrado."
                    };
                }
                var result = new ServiceResult
                {
                    Data = new BusDtoGet(
                        bus.Id,
                        bus.NumeroPlaca,
                        bus.Nombre,
                        bus.CapacidadPiso1,
                        bus.CapacidadPiso2,
                        bus.CapacidadTotal,
                        bus.Disponible,
                        bus.FechaCreacion
                    )
                };
                return result;
            }, "Ocurrió un error obteniendo el bus.");
        }

        public ServiceResult UpdateBuses(BusDtoUpdate busUpdate)
        {
            return Execute(() => {
                var validationResult = Validate(() => busUpdate == null, "Los datos del bus no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => string.IsNullOrEmpty(busUpdate.Nombre), "El nombre del bus es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => busUpdate.Nombre.Length > 50, "El nombre del bus no puede superar los 50 caracteres.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => busUpdate.CapacidadPiso1 < 0, "La capacidad del piso 1 no puede ser negativa.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => busUpdate.CapacidadPiso2 < 0, "La capacidad del piso 2 no puede ser negativa.");
                if (!validationResult.Success) return validationResult;

                var bus = busRepository.GetEntityBy(busUpdate.IdBus);
                if (bus == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Bus no encontrado."
                    };
                }
                busUpdate.UpdateEntity(bus);

                busRepository.Update(bus);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error actualizando los datos.");
        }


        public ServiceResult RemoveBuses(BusDtoRemove busRemove)
        {
            return Execute(() => {
                var validationResult = Validate(() => busRemove == null, "Los datos del bus no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                var bus = busRepository.GetEntityBy(busRemove.IdBus);
                if (bus == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Bus no encontrado."
                    };
                }
                busRepository.Remove(bus);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error removiendo los datos.");
        }

        public ServiceResult SaveBus(BusDtoAdd busAdd)
        {
            return Execute(() => {
                var validationResult = Validate(() => busAdd == null, "Los datos del bus no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => string.IsNullOrEmpty(busAdd.Nombre), "El nombre del bus es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => busAdd.Nombre.Length > 50, "El nombre del bus no puede superar los 50 caracteres.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => busAdd.CapacidadPiso1 < 0, "La capacidad del piso 1 no puede ser negativa.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => busAdd.CapacidadPiso2 < 0, "La capacidad del piso 2 no puede ser negativa.");
                if (!validationResult.Success) return validationResult;

                var busEntity = busAdd.ToEntity();

                busRepository.Save(busEntity);
                return new ServiceResult { Success = true, Data = busEntity };
            }, "Ocurrió un error grabando los datos.");
        }
    }
}













