using BoletoBusPro.Web.Models.Base;

namespace BoletoBusPro.Web.Models.Bus
{
    public class BusGetModel : BusModel {}

    public class BusListGetResult : BaseResult<List<BusGetModel>> {}
    public class BusGetResult : BaseResult<BusGetModel> {}
}


