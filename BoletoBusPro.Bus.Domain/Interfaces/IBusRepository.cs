using BoletoBusPro.Common.Data.Repository;
using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Interfaces
{
    public interface IBusRepository : IBaseRepository<Module.Domain.Entities.Bus, int>
    {
        List<Module.Domain.Entities.Bus> GetBusesById(int IdBus);
    }
}
