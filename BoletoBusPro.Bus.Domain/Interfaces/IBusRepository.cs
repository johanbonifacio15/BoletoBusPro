using BoletoBusPro.Common.Data.Repository;
using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Interfaces
{
    public interface IBusRepository : IBaseRepository<Bus, int>
    {
        List<Bus> GetBusesById(int IdBus);
    }
}
