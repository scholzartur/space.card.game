using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using FluentAssertions.Common;
using Space.Card.Game.Tests.Utils;
using Space.Card.Game.WebApi.Controllers;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Handlers.Base;
using Space.Card.Game.WebApi.Handlers.Commands;
using Space.Card.Game.WebApi.Handlers.Queires;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Interfaces;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;
using Space.Card.Game.WebApi.Interfaces.Queries;
using Xunit;

namespace Space.Card.Game.Tests.Integration
{
    public class SpaceControllerTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 10)]
        public void Assert_proper_ship_wins_battle(int idOne, int idTwo)
        {
            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                //Given
                var request = new BattleCommandRequestDto() { StarshipTwoId = idTwo, StarshipOneId = idOne };
                var spaceController = new SpaceController(GetStarshipHandler(wrapper.context),
                    GetBattleHandler(wrapper.context));
                
                //When 
                var result = (IBattleCommandResponse) spaceController.StartBattle(request);

                //Then
                result.WinnerFound.Should().BeTrue();
                result.WinnerShip.Id.Should().Be(idTwo);
            }
            
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(3, 8)]
        public void Assert_proper_ships_are_return(int startingIndex, int amountToReturn)
        {
            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                //Given
                var request = new StarshipQueryRequestDto()
                {
                    StartingIndex = startingIndex, 
                    AmountToReturn = amountToReturn
                };
                var spaceController = new SpaceController(GetStarshipHandler(wrapper.context),
                    GetBattleHandler(wrapper.context));

                //When 
                var result = (IStarshipQueryResponse)spaceController.GetStarships(request);

                //Then
                result.Starships.Count.IsSameOrEqualTo(amountToReturn);
                result.Starships.FirstOrDefault().Id = startingIndex;
            }

        }
        private IHandlerExecutor<StarshipQueryResponseDto> GetStarshipHandler(ApiContext context) =>
            new HandlerExecutor<StarshipQueryResponseDto>(
                new StarshipQueryHandler<StarshipQueryResponseDto>(context, MapperForTests.GetMapper()));

        private IHandlerExecutor<BattleCommandResponseDto> GetBattleHandler(ApiContext context) =>
            new HandlerExecutor<BattleCommandResponseDto>(
                new BattleCommandHandler<BattleCommandResponseDto>(context, MapperForTests.GetMapper()));

    }
}
