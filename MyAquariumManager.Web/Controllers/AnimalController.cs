using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Common;
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
            var dataTableFilters = new DataTableFilters(Request.Query["draw"].FirstOrDefault() ?? string.Empty, int.Parse(Request.Query["start"].FirstOrDefault() ?? "0"), int.Parse(Request.Query["length"].FirstOrDefault() ?? "10"), Request.Query["order[0][column]"].FirstOrDefault() ?? string.Empty, Request.Query["order[0][dir]"].FirstOrDefault() ?? string.Empty);
            dataTableFilters.SetSortColumnName(Request.Query[$"columns[{dataTableFilters.SortColumnIndex}][data]"].FirstOrDefault() ?? string.Empty);

            var result = await _animalService.CarregarTabelaAnimaisAsync(dataTableFilters);

            if (result.IsFailure)
                return Json(new { draw = dataTableFilters.Draw, recordsTotal = 0, recordsFiltered = 0, data = new List<TableAnimalDto>() });

            return Json(
                new { 
                    draw = Request.Query["draw"].FirstOrDefault(),
                    recordsTotal = result.Value.TotalGeral,
                    recordsFiltered = result.Value.TotalFiltrado,
                    data = result.Value.Dados 
                }
            );
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
