namespace BoletoBusPro.Web.Models.Base
{
    public class BaseResult<TModel>
    {
        public string message { get; set; }
        public bool success { get; set; }
        public TModel result { get; set; }
    }
}
