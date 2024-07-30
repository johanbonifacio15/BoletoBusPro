using BoletoBusPro.Web.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BoletoBusPro.Web.Controllers
{
    public abstract class BaseController<TModel, TSaveModel, TUpdateModel> : Controller
        where TModel : class
        where TSaveModel : class
        where TUpdateModel : class
    {
        private readonly string _apiBaseUrl;
        private readonly HttpClientHandler _httpClientHandler;

        protected BaseController(string apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => true
            };
        }

        protected abstract string GetAllUrl { get; }
        protected abstract string GetByIdUrl { get; }
        protected abstract string CreateUrl { get; }
        protected abstract string UpdateUrl { get; }

        public async Task<ActionResult> Index()
        {
            List<TModel> models = new List<TModel>();

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{_apiBaseUrl}{GetAllUrl}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        // Ajusta la deserialización si el JSON es un array directamente
                        models = JsonConvert.DeserializeObject<List<TModel>>(apiResponse) ?? new List<TModel>();
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los datos.";
                        return View(new List<TModel>());
                    }
                }
            }
            return View(models);
        }


        public async Task<ActionResult> Details(int id)
        {
            TModel model = default;

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{_apiBaseUrl}{GetByIdUrl}?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<TModel>(apiResponse);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los datos.";
                        return View();
                    }
                }
            }

            if (model == null)
            {
                ViewBag.Message = "No se encontró el registro.";
                return View(); 
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TSaveModel model)
        {
            try
            {
                using (var httpClient = new HttpClient(_httpClientHandler))
                {
                    var url = $"{_apiBaseUrl}{CreateUrl}";

                    using (var response = await httpClient.PostAsJsonAsync(url, model))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            ViewBag.Message = "Error al crear el registro.";
                            return View(model);
                        }
                    }
                }
            }
            catch
            {
                ViewBag.Message = "Error al procesar la solicitud.";
                return View(model);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            TUpdateModel model = default;

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"{_apiBaseUrl}{GetByIdUrl}?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<TUpdateModel>(apiResponse);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los datos.";
                        return View();
                    }
                }
            }

            if (model == null)
            {
                ViewBag.Message = "No se encontró el registro.";
                return View();
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TUpdateModel model)
        {
            try
            {
                using (var httpClient = new HttpClient(_httpClientHandler))
                {
                    var url = $"{_apiBaseUrl}{UpdateUrl}";

                    using (var response = await httpClient.PostAsJsonAsync(url, model))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<BaseResult<TUpdateModel>>(apiResponse);

                            if (!result.success)
                            {
                                ViewBag.Message = result.message;
                                return View(model);
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Error al actualizar el registro.";
                            return View(model);
                        }
                    }
                }
            }
            catch
            {
                ViewBag.Message = "Error al procesar la solicitud.";
                return View(model);
            }
            return View(model);
        }
    }
}


