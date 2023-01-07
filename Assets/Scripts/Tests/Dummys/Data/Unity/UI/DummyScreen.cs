using System.Threading.Tasks;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyScreen : IScreen
    {
        public async Task FadeIn()
        {
            await Task.Yield();
        }

        public async Task FadeOut()
        {
            await Task.Yield();
        }
    }
}