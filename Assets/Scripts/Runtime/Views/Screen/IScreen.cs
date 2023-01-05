using System.Threading.Tasks;

namespace NotEnoughMemory.View
{
    public interface IScreen
    {
        Task FadeIn();

        Task FadeOut();
    }
}