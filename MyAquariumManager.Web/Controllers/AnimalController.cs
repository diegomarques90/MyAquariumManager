using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Application.Interfaces.Services;

namespace MyAquariumManager.Web.Controllers
{
    [Authorize] 
    public class AnimalController(IAnimalService animalService) : Controller
    {
        private readonly IAnimalService _animalService = animalService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("carregar-table-animais")]
        public async Task<IActionResult> CarregarTableAnimais()
        {
            var result = await _animalService.ObterAnimaisAsync();

            if (result.IsFailure)
                return Json(new { data = new List<AnimalDto>() });

            return Json(new { data = result.Value });
        }
    }
}
