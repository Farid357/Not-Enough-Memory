using NotEnoughMemory.UI;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyWindows : IWindows
    {
        public IWindow Exit => new DummyWindow();

        public IWindow Loading => new DummyWindow();
    }
}