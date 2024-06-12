using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TortoiseGarden.Core.Business;
using TortoiseGarden.WebApplication.Models;

namespace TortoiseGarden.WebApplication.Controllers
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

        public IActionResult Ingreso()
        {
            return View();
        }

        public JsonResult RegistrarUsuario(string name, string password)
        {
                bool registroExitoso = new UserBusiness().RegistrarUsuario(password,name);

                if (registroExitoso)
                {
                    return Json(new { success = true, message = "Registro exitoso" });
                }
                else
                {
                    return Json(new { success = false, message = "Error al registrar usuario" });
                }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
