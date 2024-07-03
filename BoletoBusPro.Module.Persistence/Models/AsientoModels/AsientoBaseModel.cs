using System.ComponentModel.DataAnnotations;

namespace BoletoBusPro.Module.Domain.Models.AsientoModels
{
    public class AsientoBaseModel
    {
        [Key] public int IdAsiento { get; set; }
        public int IdBus { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

