using System;
using System.Threading;
using FluentAssertions;
using Space.Card.Game.Tests.Utils;
using Space.Card.Game.WebApi.Common;
using Space.Card.Game.WebApi.Dtos;
using Space.Card.Game.WebApi.Handlers.Commands;
using Space.Card.Game.WebApi.Infrastructure;
using Space.Card.Game.WebApi.Interfaces.Base;
using Space.Card.Game.WebApi.Interfaces.Commands;
using Xunit;


namespace Space.Card.Game.Tests.Unit
{
    public class BattleCommandHanlderTests
    {

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        public void Assert_that_starships_with_greater_crew_wins(int starshipOneId, int starshipTwoId)
        {
            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                //Given
                var handler = GetBattleCommandHandler(wrapper.context);
                var request = GetBattleCommandRequest(starshipOneId, starshipTwoId);

                //When
                var result = (IBattleCommandResponse)handler.Execute(request);

                //Then
                result.WinnerFound.Should().BeTrue();
                result.WinnerShip.Id.Should().Be(starshipTwoId);

            }
        }

        [Theory]
        [InlineData(5, 6)]
        [InlineData(7, 8)]
        [InlineData(9, 10)]
        public void Assert_that_starship_winCounter_is_incremented(int starshipOneId, int starshipTwoId)
        {
            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                lock (wrapper.context)
                {
                    //Given
                    var handler = GetBattleCommandHandler(wrapper.context);
                    var request = GetBattleCommandRequest(starshipOneId, starshipTwoId);

                    //When
                    var previousWinCounter = ((IBattleCommandResponse)handler.Execute(request)).WinnerShip.AmountOfWins;
                    var currentWinCounter = ((IBattleCommandResponse)handler.Execute(request)).WinnerShip.AmountOfWins;
                    Thread.Sleep(100);
                    //Then
                    currentWinCounter.Should().Be(previousWinCounter + 1);
                }
            }
        }

        [Theory]
        [InlineData(1, 11)]
        [InlineData(2, 12)]
        [InlineData(3, 13)]
        public void Assert_that_starships_with_equal_crew_draws(int starshipOneId, int starshipTwoId)
        {
            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                //Given
                var handler = GetBattleCommandHandler(wrapper.context);
                var request = GetBattleCommandRequest(starshipOneId, starshipTwoId);

                //When
                var result = (IBattleCommandResponse)handler.Execute(request);

                //Then
                result.WinnerFound.Should().BeFalse();
                result.WinnerShip.Should().BeNull();
            }
        }

        [Theory]
        [InlineData(1, int.MaxValue)]
        [InlineData(int.MaxValue, 2)]
        public void Assert_that_exception_is_thrown_when_starship_not_found(int starshipOneId, int starshipTwoId)
        {

            using (var wrapper = new ContextForTests().GetContextWrapper())
            {
                //Given
                var handler = GetBattleCommandHandler(wrapper.context);
                var request = GetBattleCommandRequest(starshipOneId, starshipTwoId);

                //When
                Action act = () => handler.Execute(request);

                //Then
                act.Should().Throw<BussinessException>()
                            .WithMessage(Messages.StarshipIsNull);
            }
        }

        private IHandlerBase<BattleCommandResponseDto> GetBattleCommandHandler(ApiContext context) =>
            new BattleCommandHandler<BattleCommandResponseDto>(context, MapperForTests.GetMapper());

        private IBattleCommandRequest GetBattleCommandRequest(int id1, int id2) => new BattleCommandRequestDto()
        {
            StarshipOneId = id1,
            StarshipTwoId = id2
        };
    }
}
