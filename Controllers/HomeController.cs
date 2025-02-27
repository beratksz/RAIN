using System.Diagnostics;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RAIN.Models;

namespace RAIN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult iletisim()
        {
            return View();
        }

        public IActionResult bireysel_ter()
        {
            return View();
        }
        public IActionResult kurumsal_ter()
        {
            return View();

        }
        public IActionResult ekibimiz()
        {
            return View();

        }
        public IActionResult aile_ter()
        {
            return View();
        }
        public IActionResult cift_ter()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/SubmitForm")]
        public async Task<IActionResult> SubmitForm([FromBody] Hasta formData)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var json = JsonSerializer.Serialize(formData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://localhost:7009/api/hastalar", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, message = "API isteði baþarýsýz oldu." });
                    }
                }
            }

            return Json(new { success = false, message = "Geçersiz form verisi." });
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
