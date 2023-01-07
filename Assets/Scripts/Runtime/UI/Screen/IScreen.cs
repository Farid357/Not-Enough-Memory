using System.Threading.Tasks;

namespace NotEnoughMemory.UI
{
    public interface IScreen
    {
        Task FadeIn();

        Task FadeOut();
    }
}