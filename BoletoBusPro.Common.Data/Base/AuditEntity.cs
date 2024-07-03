
namespace BoletoBusPro.Common.Data.Base
{
    public abstract class AuditEntity<TType> : BaseEntity<TType>
    {
        public DateTime FechaCreacion { get; set; }
    }
}
