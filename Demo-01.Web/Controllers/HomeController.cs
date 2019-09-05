namespace Demo_01.Controllers
{
    using Demo_01.Models;
    using Demo01.Model;
    using Demo01.Web.Models;
    using Demo01.Web.Util;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    /// <summary>
    /// Home controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly IOptions<SettingModel> appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="app">The application.</param>
        public HomeController(IOptions<SettingModel> app)
        {
            appSettings = app;
            AppSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var data = await ApiClientInstance.Instance.GetAsync<PagedResponse<PatientModel>>("data");
            return View(data);
        }

        /// <summary>
        /// Indexes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(PatientModel request)
        {
            TryValidateModel(request);

            if (ModelState.IsValid)
            {
                try
                {
                    var data = await ApiClientInstance.Instance.PostAsync<PatientModel>("data", request);
                    if (data != null)
                    {
                        var tempData = await ApiClientInstance.Instance.GetAsync<PagedResponse<PatientModel>>("data");
                        return View(tempData);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Save_error", ex.Message);
                }
            }
            return View(request);
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}