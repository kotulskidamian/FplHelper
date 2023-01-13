using AutoMapper;
using FplHelperApi.Dtos;
using FplHelperApi.Models;

namespace FplHelperApi.Profiles
{
    public class FplHelperProfile : Profile
    {
        public FplHelperProfile()
        {
            // Source -> Target
            CreateMap<Player, PlayerReadDto>();
            CreateMap<Player, PlayerDetailsReadDto>();

            CreateMap<Team, TeamReadDto>();
            CreateMap<Position, PositionReadDto>();
        }
    }
}
