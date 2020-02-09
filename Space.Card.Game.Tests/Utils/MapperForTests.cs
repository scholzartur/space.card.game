using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Space.Card.Game.WebApi.Infrastructure;

namespace Space.Card.Game.Tests.Utils
{
    public class MapperForTests
    {
        public static IMapper GetMapper()
        {
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}
