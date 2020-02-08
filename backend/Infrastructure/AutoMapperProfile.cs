using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //.ForMember(dest => dest.AmountOfPeopleInCrew,
            //    o => o.MapFrom(src => src.AmountOfPeopleInCrew));

        }
    }
}
