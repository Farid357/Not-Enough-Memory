using NotEnoughMemory.UI;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyTexts : ITexts
    {
        public IText Money => new DummyText();
        
        public IText Loading => new DummyText();
    }
}