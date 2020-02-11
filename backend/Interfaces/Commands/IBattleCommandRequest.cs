using Space.Card.Game.WebApi.Interfaces.Base;

namespace Space.Card.Game.WebApi.Interfaces.Commands
{
    public interface IBattleCommandRequest: IRequestBase
    {
         int StarshipOneId { get; set; }
         int StarshipTwoId { get; set; }
    }
}
