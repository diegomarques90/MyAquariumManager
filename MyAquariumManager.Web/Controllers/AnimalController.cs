using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Application.Interfaces.Services;

namespace MyAquariumManager.Web.Controllers
{
    [Authorize]
    public class AnimalController(IAnimalService animalService) : BaseController
    {
        private readonly IAnimalService _animalService = animalService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("carregar-table-animais")]
        public async Task<IActionResult> CarregarTableAnimais()
        {
            var result = await _animalService.CarregarTabelaAnimaisAsync();

            if (result.IsFailure)
                return Json(new { data = new List<TableAnimalDto>() });

            return Json(new { data = result.Value });
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAnimal([FromBody] CriarAnimalDto model)
        {
            if (model is null)
                return BadRequest(new { success = false, errors = new List<string> { "CriarAnimalDto não pode ser nulo." } });

            model.UsuarioCriacao = UsuarioLogado.Email;
            model.CodigoConta = ContaLogada.CodigoConta;

            var result = await _animalService.CadastrarAnimalAsync(model);

            if (result.IsFailure)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, result.Value.Id });
        }
    }
}
