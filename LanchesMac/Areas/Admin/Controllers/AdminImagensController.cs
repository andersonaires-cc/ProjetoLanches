using LanchesMac.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

   
        public AdminImagensController(IWebHostEnvironment hostEnvironment,
                                        IOptions<ConfigurationImagens> myConfiguration)
        {
            _hostingEnvironment = hostEnvironment;
            _myConfig = myConfiguration.Value;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
