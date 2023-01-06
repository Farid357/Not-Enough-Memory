using NotEnoughMemory.Game.Loop;

namespace NotEnoughMemory.Game
{
    public interface IGame
    {
        IGameTime Time {get;}
        
        IGameLoop Loop { get; }
    }
}