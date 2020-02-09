using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using FluentAssertions.Common;
using Space.Card.Game.Tests.Utils;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Handlers.Commands;
using Space.Card.Game.WebApi.Handlers.Queires;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;
using Space.Card.Game.WebApi.Interfaces.Queries;
using Xunit;

namespace Space.Card.Game.Tests.Unit
{
    public class StarshipQueryHandlerTests
    {
        [Fact]
        public void Assert_that_all_starships_are_returned()
        {
            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                //Given
                var handler = GetStarshipQueryHandler(wrapper.context);
                var request = GetStarshipQueryRequest();

                //When
                var result = (IStarshipQueryResponse) handler.Execute(request);

                //Then
                result.Starships.Count.IsSameOrEqualTo(wrapper.context.Starships.Count());
            }
        }

        private IHandlerBase<StarshipQueryResponseDto> GetStarshipQueryHandler(ApiContext context) =>
            new StarshipQueryHandler<StarshipQueryResponseDto>(context, MapperForTests.GetMapper());

        private IStarshipQueryRequest GetStarshipQueryRequest() => new StarshipQueryRequestDto();

    }
}
