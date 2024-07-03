using BoletoBusPro.Module.Domain.Entities;

namespace BoletoBusPro.Module.Domain.Exceptions
{
    public class BusException : Exception
    {
        public BusException(string message) : base(message)
        {
        }

        public static void VerifyExistence(Bus bus, int idBus)
        {
            if (bus == null)
            {
                throw new BusException($"El bus con la id {idBus} no está registrado.");
            }
        }
    }
}

