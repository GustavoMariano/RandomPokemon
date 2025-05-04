using AutoMapper;
using RandomPokemon.Contracts.Dtos;
using RandomPokemon.Domain.Enums;
using RandomPokemon.Domain.Models;

namespace RandomPokemon.Api.Mappings;

public class PokemonProfile : Profile
{
    public PokemonProfile()
    {
        CreateMap<Pokemon, PokemonDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.PokedexId, opt => opt.MapFrom(src => src.PokedexId))
            .ForMember(dest => dest.TypeOne, opt => opt.MapFrom(src => src.TypeOne.ToString()))
            .ForMember(dest => dest.TypeTwo, opt => opt.MapFrom(src => src.TypeTwo.HasValue ? src.TypeTwo.Value.ToString() : null))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
            .ForMember(dest => dest.Silhouette, opt => opt.MapFrom(src => src.Silhouette));

        CreateMap<PokemonDto, Pokemon>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.PokedexId, opt => opt.MapFrom(src => src.PokedexId))
            .ForMember(dest => dest.TypeOne, opt => opt.MapFrom(src => Enum.Parse<EType>(src.TypeOne)))
            .ForMember(dest => dest.TypeTwo, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.TypeTwo) ? null : (EType?)Enum.Parse<EType>(src.TypeTwo)))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
            .ForMember(dest => dest.Silhouette, opt => opt.MapFrom(src => src.Silhouette))
            .ForMember(dest => dest.Evolutions, opt => opt.Ignore());
    }
}
