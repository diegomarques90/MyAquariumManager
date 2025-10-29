using MyAquariumManager.Core.Constants;
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

        public PlantaBuilder ComONomeInvalido()
        {
            _planta.Nome = string.Empty;
            return this;
        }

        public PlantaBuilder ComNomeMaiorQueOPermitido()
        {
            _planta.Nome = new string('A', 201);
            return this;
        }

        public PlantaBuilder ComNomeCientificoMaiorQueOPermitido()
        {
            _planta.NomeCientifico = new string('A', 201);
            return this;
        }

        public PlantaBuilder ComLocalAquisicaoMaiorQueOPermitido()
        {
            _planta.LocalAquisicao = new string('A', 101);
            return this;
        }

        public PlantaBuilder ComDataAquisicaoFutura()
        {
            _planta.DataAquisicao = DateTime.UtcNow.AddDays(5);
            return this;
        }

        public PlantaBuilder ComFaixaDeTamanhoMaiorQueOPermitido()
        {
            _planta.FaixaDeTamanho = new string('A', 101);
            return this;
        }

        public PlantaBuilder ComTipoDeCrescimentoInvalido()
        {
            _planta.TipoDeCrescimento = (TipoDeCrescimento)999;
            return this;
        }

        public PlantaBuilder ComTipoDeIluminacaoInvalido()
        {
            _planta.TipoDeIluminacao = (TipoDeIluminacao)999;
            return this;
        }

        public PlantaBuilder ComTipoDePlantioInvalido()
        {
            _planta.TipoDePlantio = (TipoDePlantio)999;
            return this;
        }

        public PlantaBuilder ComFaixaDoPhMaiorQueOPermitido()
        {
            _planta.FaixaDoPH = new string('A', 101);
            return this;
        }

        public PlantaBuilder ComFaixaDeTemperaturaMaiorQueOPermitido()
        {
            _planta.FaixaDeTemperatura = new string('A', 101);
            return this;
        }

        public PlantaBuilder ComNivelDeCultivoMaiorQueOPermitido()
        {
            _planta.NivelDeCutivo = new string('A', 101);
            return this;
        }

        public PlantaBuilder ComFormaDeReproducaoMaiorQueOPermitido()
        {
            _planta.FormaDeReproducao = new string('A', 101);
            return this;
        }

        public PlantaBuilder ComInformacoesAdicionaisMaiorQueOPermitido()
        {
            _planta.InformacoesAdicionais = new string('A', 801);
            return this;
        }

        public PlantaBuilder ComUsuarioAlteracao()
        {
            _planta.Atualizar(BaseConstants.USER_UNIT_TESTS);
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
