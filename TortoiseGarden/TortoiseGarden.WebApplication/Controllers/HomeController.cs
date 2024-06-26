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

        [HttpPost]
        public JsonResult RegistrarUsuario([FromBody] UsuarioDTO usuario)
        {
                bool registroExitoso = new UserBusiness().RegistrarUsuario(usuario.pass,usuario.name);

                if (registroExitoso)
                {
                    return Json(new { success = true, message = "Registro exitoso" });
                }
                else
                {
                    return Json(new { success = false, message = "Error al registrar usuario" });
                }

        }
        [HttpPost]
        public JsonResult AutenticarUsuario([FromBody] UsuarioDTO usuario)
        {
            bool autenticacionExitosa = new UserBusiness().AutenticarUsuario(usuario.pass, usuario.name);

            if (autenticacionExitosa)
            {
                return Json(new { success = true, message = $"Autenticacion exitosa" });
            }
            else
            {
                return Json(new { success = false, message = $"Error en la autenticación" });
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public class UsuarioDTO
        {
            public string name { get; set; }
            public string pass { get; set; }
        }
    }
}
