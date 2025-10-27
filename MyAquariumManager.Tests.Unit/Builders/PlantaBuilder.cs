using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Tests.Unit.Builders
{
    public class PlantaBuilder
    {
        private const string USUARIO_CRIACAO = "usertests@email.com";
        private readonly Planta _planta;

        public PlantaBuilder()
        {
            _planta = new Planta(USUARIO_CRIACAO)
            {
                CodigoConta = ObterCodigoConta()
            };
        }

        public PlantaBuilder ComTodosOsDadosValidos()
        {
            _planta.Nome = "Mini-cálamo-do-japão";
            _planta.NomeCientifico = "Acorus gramineus";
            _planta.LocalAquisicao = "Eco Marine";
            _planta.DataAquisicao = DateTime.Now.AddDays(-10);
            _planta.FaixaDeTamanho = "10-15 cm";
            _planta.TipoDeCrescimento = TipoDeCrescimento.Lento;
            _planta.TipoDeIluminacao = TipoDeIluminacao.Forte;
            _planta.FaixaDoPH = "6.4 a 7.2";
            _planta.FaixaDeTemperatura = "19-22 °C";
            _planta.NivelDeCutivo = "Iniciante";
            _planta.TipoDePlantio = TipoDePlantio.FundoEMeio;
            _planta.FormaDeReproducao = "Divisão de touceiras";
            _planta.ExigeCO2 = false;
            _planta.InformacoesAdicionais = " ideal para bordas de lagos, cursos d’água e áreas com drenagem deficiente.";

            return this;
        }

        public Planta Build() => _planta;
        
        private static string ObterCodigoConta()
        {
            var conta = new Conta(USUARIO_CRIACAO);
            var resultadoOperacao = conta.CriarCodigoConta();

            if (resultadoOperacao.IsFailure)
                return "codigoTeste";
            else
                return resultadoOperacao.Value;
        }
    }
}
