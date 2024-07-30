using BoletoBusPro.Web.Models.Asiento;

namespace BoletoBusPro.Web.Controllers
{
    public class AsientoController : BaseController<AsientoGetModel, AsientoSaveModel, AsientoUpdateModel>
    {
        public AsientoController() : base("http://localhost:5110/api/Asiento") { }

        protected override string GetAllUrl => "/GetAsientos";
        protected override string GetByIdUrl => "/GetAsiento";
        protected override string CreateUrl => "/SaveAsiento";
        protected override string UpdateUrl => "/UpdateAsiento";
    }
}





