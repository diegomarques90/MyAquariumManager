using AutoMapper;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Application.Mappers
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalDto>();

            CreateMap<Animal, CriarAnimalDto>();

            CreateMap<CriarAnimalDto, Animal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());

            CreateMap<AnimalDto, Animal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioAlteracao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAlteracao, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioExclusao, opt => opt.Ignore())
                .ForMember(dest => dest.DataExclusao, opt => opt.Ignore());
                
            CreateMap<AtualizarAnimalDto, Animal>()
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataAlteracao, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioExclusao, opt => opt.Ignore())
                .ForMember(dest => dest.DataExclusao, opt => opt.Ignore());
        }
    }
}
