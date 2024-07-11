using BoletoBusPro.Module.Application.Core;
using BoletoBusPro.Module.Application.Dtos.AsientoDto;
using BoletoBusPro.Module.Application.Extensions;
using BoletoBusPro.Module.Application.Interfaces;
using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoletoBusPro.Module.Application.Services
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository asientoRepository;
        private readonly ILogger logger;

        public AsientoService(IAsientoRepository asientoRepository, ILogger<AsientoService> logger)
        {
            this.asientoRepository = asientoRepository;
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

        public ServiceResult GetAsientos()
        {
            return Execute(() => {
                var asientos = asientoRepository.GetAll();
                var result = new ServiceResult
                {
                    Data = asientos.Select(asiento => new AsientoDtoGet(
                        asiento.Id,
                        asiento.IdBus,
                        asiento.NumeroPiso,
                        asiento.NumeroAsiento
                    )).ToList()
                };
                return result;
            }, "Hubo un error durante la obtención de los asientos.");
        }

        public ServiceResult GetAsiento(int id)
        {
            return Execute(() => {
                var asiento = asientoRepository.GetEntityBy(id);
                if (asiento == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Asiento no encontrado."
                    };
                }
                var result = new ServiceResult
                {
                    Data = new AsientoDtoGet(
                        asiento.Id,
                        asiento.IdBus,
                        asiento.NumeroPiso,
                        asiento.NumeroAsiento
                    )
                };
                return result;
            }, "Ocurrió un error obteniendo el asiento.");
        }

        public ServiceResult UpdateAsiento(AsientoDtoUpdate asientoUpdate)
        {
            return Execute(() => {
                var validationResult = Validate(() => asientoUpdate == null, "Los datos del asiento no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => asientoUpdate.IdBus <= 0, "El Id del bus es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => asientoUpdate.NumeroAsiento <= 0, "El número de asiento es requerido.");
                if (!validationResult.Success) return validationResult;

                var asiento = asientoRepository.GetEntityBy(asientoUpdate.IdAsiento); // Obtén la entidad existente
                if (asiento == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Asiento no encontrado."
                    };
                }
                asientoUpdate.UpdateEntity(asiento); // Actualiza la entidad con los nuevos datos

                asientoRepository.Update(asiento);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error actualizando los datos.");
        }

        public ServiceResult RemoveAsiento(AsientoDtoRemove asientoRemove)
        {
            return Execute(() => {
                var validationResult = Validate(() => asientoRemove == null, "Los datos del asiento no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                var asiento = asientoRepository.GetEntityBy(asientoRemove.IdAsiento); // Obtén la entidad existente
                if (asiento == null)
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Asiento no encontrado."
                    };
                }
                asientoRepository.Remove(asiento);
                return new ServiceResult { Success = true };
            }, "Ocurrió un error removiendo los datos.");
        }

        public ServiceResult SaveAsiento(AsientoDtoAdd asientoAdd)
        {
            return Execute(() => {
                var validationResult = Validate(() => asientoAdd == null, "Los datos del asiento no pueden ser nulos.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => asientoAdd.IdBus <= 0, "El Id del bus es requerido.");
                if (!validationResult.Success) return validationResult;

                validationResult = Validate(() => asientoAdd.NumeroAsiento <= 0, "El número de asiento es requerido.");
                if (!validationResult.Success) return validationResult;

                var asientoEntity = new Asiento
                {
                    IdBus = asientoAdd.IdBus,
                    NumeroPiso = asientoAdd.NumeroPiso,
                    NumeroAsiento = asientoAdd.NumeroAsiento,
                    FechaCreacion = DateTime.Now // Configurando fecha de creación
                };

                asientoRepository.Save(asientoEntity);
                return new ServiceResult { Success = true, Data = asientoEntity };
            }, "Ocurrió un error grabando los datos.");
        }
    }
}






