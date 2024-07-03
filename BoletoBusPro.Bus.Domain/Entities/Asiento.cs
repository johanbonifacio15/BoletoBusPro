using BoletoBusPro.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoBusPro.Module.Domain.Entities
{
    public class Asiento : AuditEntity<int>
    {
        [Column("IdAsiento")]
        public override int Id { get; set; }
        public int IdBus { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
    }
}

