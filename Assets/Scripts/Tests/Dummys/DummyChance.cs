using NotEnoughMemory.Model;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyChance : IChance
    {
        private readonly bool _isLucky;

        public DummyChance(bool isLucky)
        {
            _isLucky = isLucky;
        }

        public bool TryGetLucky()
        {
            return _isLucky;
        }
    }
}