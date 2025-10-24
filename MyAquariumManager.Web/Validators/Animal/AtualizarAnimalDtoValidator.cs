using FluentValidation;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Constants;

namespace MyAquariumManager.Web.Validators.Animal
{
    public class AtualizarAnimalDtoValidator : AbstractValidator<AtualizarAnimalDto>
    {
        public AtualizarAnimalDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(BaseConstants.ID_NAO_PODE_SER_NULO_OU_VAZIO);

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

            RuleFor(x => x.Especie)
                .MaximumLength(100).WithMessage(BaseConstants.ESPECIE_QUANTIDADE_MAXIMA);

            RuleFor(x => x.FaixaDoPH)
                .MaximumLength(100).WithMessage(BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA);

            RuleFor(x => x.Origem)
                .MaximumLength(100).WithMessage(BaseConstants.ORIGEM_QUANTIDADE_MAXIMA);

            RuleFor(x => x.Comportamento)
                .MaximumLength(100).WithMessage(BaseConstants.COMPORTAMENTO_QUANTIDADE_MAXIMA);

            RuleFor(x => x.QuantidadeMinima)
                .NotNull().WithMessage(BaseConstants.QUANTIDADE_MINIMA_IDEAL_OBRIGATORIA)
                .ExclusiveBetween(0, int.MaxValue).WithMessage(BaseConstants.QUANTIDADE_MINIMA_IDEAL_MAIOR_QUE_ZERO);

            RuleFor(x => x.LitragemMinima)
                .NotNull().WithMessage(BaseConstants.LITRAGEM_MINIMA_IDEAL_OBRIGATORIA)
                .ExclusiveBetween(0, int.MaxValue).WithMessage(BaseConstants.LITRAGEM_MINIMA_IDEAL_MAIOR_QUE_ZERO);

            RuleFor(x => x.TipoDeAlimentacao)
                .NotNull().WithMessage(BaseConstants.TIPO_ALIMENTACAO_OBRIGATORIO)
                .IsInEnum().WithMessage(BaseConstants.TIPO_ALIMENTACAO_INVALIDO);

            RuleFor(x => x.FaixaDeTamanho)
                .MaximumLength(100).WithMessage(BaseConstants.FAIXA_TAMANHO_QUANTIDADE_MAXIMA);

            RuleFor(x => x.FaixaDeTemperatura)
                .MaximumLength(100).WithMessage(BaseConstants.FAIXA_TEMPERATURA_QUANTIDADE_MAXIMA);

            RuleFor(x => x.TipoDeAgua)
                .NotNull().WithMessage(BaseConstants.TIPO_AGUA_OBRIGATORIO)
                .IsInEnum().WithMessage(BaseConstants.TIPO_AGUA_INVALIDO);

            RuleFor(x => x.InformacoesAdicionais)
                .MaximumLength(800).WithMessage(BaseConstants.INFORMACOES_ADICIONAIS_QUANTIDADE_MAXIMA);
        }
    }
}
