namespace NotEnoughMemory.View
{
    public interface ITextView
    {
        void Visualize(string line);

        void Visualize(int count);
    }
}