using NotEnoughMemory.UI;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyTextsData : ITextsData
    {
        public IText Money => new DummyText();
        
        public IText Loading => new DummyText();
    }
}