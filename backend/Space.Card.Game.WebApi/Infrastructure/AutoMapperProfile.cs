using AutoMapper;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Model;

namespace Space.Card.Game.WebApi.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Starship, StarshipDto>();
        }
    }
}
