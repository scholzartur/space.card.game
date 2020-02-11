using System.Linq;
using FluentAssertions.Common;
using Space.Card.Game.Tests.Utils;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Handlers.Queires;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Queries;
using Xunit;

namespace Space.Card.Game.Tests.Unit
{
    public class StarshipQueryHandlerTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        public void Assert_that_proper_starships_are_returned(int startId, int amountToReturn)
        {
            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                //Given
                var handler = GetStarshipQueryHandler(wrapper.context);
                var request = GetStarshipQueryRequest(startId, amountToReturn);

                //When
                var result = (IStarshipQueryResponse)handler.Execute(request);

                //Then
                result.Starships.Count.IsSameOrEqualTo(amountToReturn);
                result.Starships.FirstOrDefault().Id = startId;
            }
        }

        private IHandlerBase<StarshipQueryResponseDto> GetStarshipQueryHandler(ApiContext context) =>
            new StarshipQueryHandler<StarshipQueryResponseDto>(context, MapperForTests.GetMapper());

        private IStarshipQueryRequest GetStarshipQueryRequest(int startId, int amountToReturn) =>
            new StarshipQueryRequestDto
            {
                StartingIndex = startId,
                AmountToReturn = amountToReturn
            };
    }
}
