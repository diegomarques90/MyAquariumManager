using FluentValidation;
using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Core.Constants;

namespace MyAquariumManager.Web.Validators.Planta
{
    public class CriarPlantaDtoValidator : AbstractValidator<CriarPlantaDto>
    {
        public CriarPlantaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage(BaseConstants.NOME_OBRIGATORIO)
                .MaximumLength(200).WithMessage(BaseConstants.NOME_QUANTIDADE_MAXIMA);

            RuleFor(x => x.NomeCientifico)
                .MaximumLength(200).WithMessage(BaseConstants.NOME_CIENTIFICO_QUANTIDADE_MAXIMA);

            RuleFor(x => x.LocalAquisicao)
                .MaximumLength(100).WithMessage(BaseConstants.LOCAL_AQUISICAO_QUANTIDADE_MAXIMA);

            When(x => x.DataAquisicao.HasValue, () => 
            {
                RuleFor(x => x.DataAquisicao)
                    .LessThan(DateTime.Now).WithMessage(BaseConstants.DATA_AQUISICAO_NAO_PODE_SER_FUTURA);
            });

            RuleFor(x => x.FaixaDeTamanho)
                .MaximumLength(100).WithMessage(BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA);

            RuleFor(x => x.TipoDeCrescimento)
                .NotNull().WithMessage(BaseConstants.TIPO_CRESCIMENTO_OBRIGATORIO)
                .IsInEnum().WithMessage(BaseConstants.TIPO_CRESCIMENTO_INVALIDO);

            RuleFor(x => x.TipoDeIluminacao)
                .NotNull().WithMessage(BaseConstants.TIPO_ILUMINACAO_OBRIGATORIO)
                .IsInEnum().WithMessage(BaseConstants.TIPO_ILUMINACAO_INVALIDO);

            RuleFor(x => x.FaixaDoPH)
                .MaximumLength(100).WithMessage(BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA);

            RuleFor(x => x.FaixaDeTemperatura)
                .MaximumLength(100).WithMessage(BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA);

            RuleFor(x => x.NivelDeCutivo)
                .MaximumLength(100).WithMessage(BaseConstants.NIVEL_CULTIVO_QUANTIDADE_MAXIMA);

            RuleFor(x => x.TipoDePlantio)
                .NotNull().WithMessage(BaseConstants.TIPO_PLANTIO_OBRIGATORIO)
                .IsInEnum().WithMessage(BaseConstants.TIPO_PLANTIO_INVALIDO);

            RuleFor(x => x.FormaDeReproducao)
                .MaximumLength(100).WithMessage(BaseConstants.FORMA_REPRODUCAO_QUANTIDADE_MAXIMA);

            RuleFor(x => x.InformacoesAdicionais)
              .MaximumLength(800).WithMessage(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA);
        }
    }
}
