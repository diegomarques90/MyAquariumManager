using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyAquariumManager.Web.Controllers
{
    [Authorize] 
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
