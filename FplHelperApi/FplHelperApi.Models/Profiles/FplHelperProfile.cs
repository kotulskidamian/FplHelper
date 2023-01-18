using AutoMapper;
using FplHelperApi.Models.Dtos;

namespace FplHelperApi.Models.Profiles
{
    public class FplHelperProfile : Profile
    {
        public FplHelperProfile()
        {
            // Source -> Target
            CreateMap<Player, PlayerReadDto>();
            CreateMap<Player, PlayerDetailsReadDto>();
            CreateMap<Player, PlayerStatsReadDto>();

            CreateMap<Team, TeamReadDto>();
            CreateMap<Position, PositionReadDto>();
        }
    }
}
