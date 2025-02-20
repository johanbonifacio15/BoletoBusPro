﻿using BoletoBusPro.Common.Data.Repository;
using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Interfaces
{
    public interface IAsientoRepository : IBaseRepository<Module.Domain.Entities.Asiento, int>
    {
        List<Asiento> GetAsientosByBusId(int IdBus);
    }
}
