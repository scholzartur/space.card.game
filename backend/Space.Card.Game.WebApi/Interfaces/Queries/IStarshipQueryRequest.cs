using Space.Card.Game.WebApi.Interfaces.Base;

namespace Space.Card.Game.WebApi.Interfaces.Queries
{
    public interface IStarshipQueryRequest: IRequestBase
    {
         int StartingIndex { get; set; }
         int AmountToReturn { get; set; }
    }
}
