using BoletoBusPro.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoBusPro.Module.Domain.Entities
{
    public class Bus : AuditEntity<int>
    {
        [Column("IdBus")]
        public override int Id { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public int CapacidadTotal => CapacidadPiso1 + CapacidadPiso2;
        public bool Disponible { get; set; }
    }
}
