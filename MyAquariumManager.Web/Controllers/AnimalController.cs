using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Application.Interfaces.Services;
using System.Threading.Tasks;
using MyAquariumManager.Web.Models.Animal;

namespace MyAquariumManager.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
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

        [HttpGet("Cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpGet("Detalhes/{id:guid}")]
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var result = await _animalService.ObterAnimalPorIdAsync(id);
            
            if (result.IsFailure)
                return BadRequest(new { success = false, errors = result.Errors });

            var viewModel = DetalhesViewModel.FromAnimalDto(result.Value);

            return View("Detalhes", viewModel);
        }

        [HttpGet("Editar/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            var result = await _animalService.ObterAnimalPorIdAsync(id);

            if (result.IsFailure)
                return BadRequest(new { success = false, errors = result.Errors });

            var viewModel = EditarViewModel.FromAnimalDto(result.Value);

            return View("Editar", viewModel);
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarAnimal([FromBody] AtualizarAnimalDto dto)
        {
            dto.UsuarioAlteracao = UsuarioLogado.Email;

            var result = await _animalService.AtualizarAnimalAsync(dto);

            if (result.IsFailure)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true });
        }


        [HttpPost("CadastrarAnimal")]
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

        [HttpDelete("ExcluirAnimal/{id:guid}")]
        public async Task<IActionResult> ExcluirAnimal(Guid id) 
        {
            var result = await _animalService.ExcluirAnimalAsync(id, UsuarioLogado.Email);
            
            if (result.IsFailure)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true });
        }
    }
}
