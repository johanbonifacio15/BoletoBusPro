using BoletoBusPro.Module.Domain.Entities;
using BoletoBusPro.Module.Domain.Exceptions;
using BoletoBusPro.Module.Domain.Interfaces;
using BoletoBusPro.Module.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoletoBusPro.Module.Persistence.Repositories
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly BoletoBusContext context;

        public AsientoRepository(BoletoBusContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Asiento, bool>> filter)
        {
            return context.Asientos.Any(filter);
        }

        public List<Asiento> GetAll()
        {
            return context.Asientos.ToList();
        }

        public List<Asiento> GetAsientosByBusId(int IdBus)
        {
            return context.Asientos.Where(a => a.IdBus == IdBus).ToList();
        }

        public Asiento GetEntityBy(int Id)
        {
            var asiento = context.Asientos.Find(Id);
            AsientoException.VerifyExistence(asiento, Id);
            return asiento;
        }

        public void Remove(Asiento entity)
        {
            context.Asientos.Remove(entity);
            context.SaveChanges();
        }

        public void Save(Asiento entity)
        {
            context.Asientos.Add(entity);
            context.SaveChanges();
        }

        public void Update(Asiento entity)
        {
            var existingAsiento = context.Asientos.Find(entity.Id);
            AsientoException.VerifyExistence(existingAsiento, entity.Id);

            existingAsiento.Id = entity.Id;
            existingAsiento.IdBus = entity.IdBus;
            existingAsiento.NumeroPiso = entity.NumeroPiso;
            existingAsiento.NumeroAsiento = entity.NumeroAsiento;

            context.Asientos.Update(existingAsiento);
            context.SaveChanges();
        }
    }
}

