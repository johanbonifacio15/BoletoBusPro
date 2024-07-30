using BoletoBusPro.Web.Models.Base;

namespace BoletoBusPro.Web.Models.Asiento
{
    public class AsientoGetModel : AsientoModel {}
    public class AsientoListGetResult : BaseResult<List<AsientoGetModel>> { }
    public class AsientoGetResult : BaseResult<AsientoGetModel> { }
}

