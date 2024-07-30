using BoletoBusPro.Web.Models.Base;

namespace BoletoBusPro.Web.Models.Asiento
{
    public class AsientoModel : EntityModel
    {
        public int IdAsiento { get; set; }
        public int IdBus { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
    }
}
