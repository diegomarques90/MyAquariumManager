using FluentValidation;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Constants;

namespace MyAquariumManager.Web.Validators.Animal
{
    public class CriarAnimalDtoValidator : AbstractValidator<CriarAnimalDto>
    {
        public CriarAnimalDtoValidator()
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

            RuleFor(x => x.Especie)
                .MaximumLength(100).WithMessage(BaseConstants.ESPECIE_QUANTIDADE_MAXIMA);

            RuleFor(x => x.FaixaDoPH)
                .MaximumLength(100).WithMessage(BaseConstants.FAIXA_PH_QUANTIDADE_MAXIMA);

            RuleFor(x => x.Origem)
                .MaximumLength(100).WithMessage(BaseConstants.ORIGEM_QUANTIDADE_MAXIMA);

        }
    }
}
