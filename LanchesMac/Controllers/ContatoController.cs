using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            //Restringindo o acesso a View Contato
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login","Account");
            
        }
    }
}
