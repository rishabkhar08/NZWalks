using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            // Mapper for Region
            CreateMap<RegionDto, Region>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>();
            CreateMap<UpdateRegionRequestDto, Region>();

            // Mapper for Walk
            CreateMap<WalkDto, Walk>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            // Mapper for Difficulty
            CreateMap<DifficultyDto, Difficulty>().ReverseMap();
        }
    }
}
