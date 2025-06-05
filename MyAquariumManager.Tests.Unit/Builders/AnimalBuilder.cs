using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Tests.Unit.Builders
{
    public class AnimalBuilder
    {
        private const string USUARIO_CRIACAO = "usertests@email.com";
        private readonly Animal _animal;
        
        public AnimalBuilder()
        {
            _animal = new Animal(USUARIO_CRIACAO)
            {
                CodigoConta = ObterCodigoConta()
            };
        }

        public AnimalBuilder ComTodosOsDadosValidos()
        {
            _animal.Nome = "Tetra Neon Cardinal";
            _animal.NomeCientifico = "Paracheirodon axelrodi";
            _animal.LocalAquisicao = "Loja de Aquarismo Local";
            _animal.DataAquisicao = DateTime.Now;
            _animal.Especie = "Tetra Neon";
            _animal.FaixaDoPH = "5.0 - 7.0";
            _animal.Origem = "América do Sul";
            _animal.Comportamento = "Pacífico";
            _animal.Cardumeiro = true;
            _animal.QuantidadeMinima = 6;
            _animal.LitragemMinima = 20;
            _animal.TipoDeAlimentacao = TipoDeAlimentacao.Onivoro;
            _animal.FaixaDeTamanho = "3 - 5 cm";
            _animal.FaixaDeTemperatura = "22 - 28 °C";
            _animal.TipoDeAgua = TipoDeAgua.Doce;
            _animal.InformacoesAdicionais = "Prefere aquários com plantas e esconderijos.";
            
            return this;
        }

        public AnimalBuilder ComONomeInvalido()
        {
            _animal.Nome = string.Empty;
            return this;
        }

        public AnimalBuilder ComNomeMaiorQueOPermitido()
        {
            _animal.Nome = new string('A', 201);
            return this;
        }

        public AnimalBuilder ComNomeCientificoMaiorQueOPermitido()
        {
            _animal.NomeCientifico = new string('A', 201);
            return this;
        }

        public AnimalBuilder ComLocalAquisicaoMaiorQueOPermitido()
        {
            _animal.LocalAquisicao = new string('A', 101);
            return this;
        }

        public AnimalBuilder ComEspecieMaiorQueOPermitido()
        {
            _animal.Especie = new string('A', 101);
            return this;
        }

        public AnimalBuilder ComFaixaDoPHMaiorQueOPermitido()
        { 
            _animal.FaixaDoPH = new string('A', 101);
            return this;
        }

        public AnimalBuilder ComOrigemMaiorQueOPermitido()
        {
            _animal.Origem = new string('A', 101);
            return this;
        }

        public AnimalBuilder ComComportamentoMaiorQueOPermitido()
        {
            _animal.Comportamento = new string('A', 101);
            return this;
        }

        public AnimalBuilder ComFaixaDeTamanhoMaiorQueOPermitido()
        {
            _animal.FaixaDeTamanho = new string('A', 101);
            return this;
        }

        public AnimalBuilder ComFaixaDeTemperaturaMaiorQueOPermitido()
        {
            _animal.FaixaDeTemperatura = new string('A', 101);
            return this;
        }

        public AnimalBuilder ComInformacoesAdicionaisMaiorQueOPermitido()
        {
            _animal.InformacoesAdicionais = new string('A', 801);
            return this;
        }

        public AnimalBuilder ComQuantidadeMinimaIdealIgualAZero()
        {
            _animal.QuantidadeMinima = 0;
            return this;
        }

        public AnimalBuilder ComLitragemMinimaIdealIgualAZero()
        {
            _animal.LitragemMinima = 0;
            return this;
        }

        public AnimalBuilder ComTipoDeAlimentacaoInvalido() 
        { 
            _animal.TipoDeAlimentacao = (TipoDeAlimentacao)999;
            return this;
        }

        public AnimalBuilder ComTipoDeAguaInvalido()
        {
            _animal.TipoDeAgua = (TipoDeAgua)999;
            return this;
        }

        public AnimalBuilder ComDataAquisicaoFutura()
        {
            _animal.DataAquisicao = DateTime.Now.AddDays(14);
            return this;
        }

        public Animal Build() => _animal;

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
