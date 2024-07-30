using BoletoBusPro.Web.Models.Bus;

namespace BoletoBusPro.Web.Controllers
{
    public class BusController : BaseController<BusGetModel, BusSaveModel, BusUpdateModel>
    {
        public BusController() : base("http://localhost:5110/api/Bus") { }

        protected override string GetAllUrl => "/GetBuses";
        protected override string GetByIdUrl => "/GetBus";
        protected override string CreateUrl => "/SaveBuses";
        protected override string UpdateUrl => "/UpdateBuses";
    }
}


