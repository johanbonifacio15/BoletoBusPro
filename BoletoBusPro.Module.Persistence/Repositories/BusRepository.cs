using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Domain.Exceptions;
using BoletoBusPro.Module.Domain.Interfaces;
using BoletoBusPro.Module.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoletoBusPro.Module.Persistence.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly BoletoBusContext context;

        public BusRepository(BoletoBusContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Bus, bool>> filter)
        {
            return context.Buses.Any(filter);
        }

        public List<Bus> GetAll()
        {
            return context.Buses.ToList();
        }

        public List<Bus> GetBusesById(int IdBus)
        {
            return context.Buses.Where(b => b.Id == IdBus).ToList();
        }

        public Bus GetEntityBy(int Id)
        {
            var bus = context.Buses.Find(Id);
            BusException.VerifyExistence(bus, Id);
            return bus;
        }

        public void Remove(Bus entity)
        {
            context.Buses.Remove(entity);
            context.SaveChanges();
        }

        public void Save(Bus entity)
        {
            context.Buses.Add(entity);
            context.SaveChanges();
        }

        public void Update(Bus entity)
        {
            var existingBus = context.Buses.Find(entity.Id);
            BusException.VerifyExistence(existingBus, entity.Id);

            existingBus.NumeroPlaca = entity.NumeroPlaca;
            existingBus.Nombre = entity.Nombre;
            existingBus.CapacidadPiso1 = entity.CapacidadPiso1;
            existingBus.CapacidadPiso2 = entity.CapacidadPiso2;
            existingBus.CapacidadTotal = entity.CapacidadTotal;
            existingBus.Disponible = entity.Disponible;
            existingBus.FechaCreacion = entity.FechaCreacion;

            context.Buses.Update(existingBus);
            context.SaveChanges();
        }
    }
}



