using System;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneFactory : IFactory<ITelephone>
    {
        private readonly ITelephoneView _telephoneView;
        private readonly IMemoryView _memoryView;
        private readonly IMemory _memory;

        public TelephoneFactory(ITelephoneView telephoneView, IMemoryView memoryView, IMemory memory)
        {
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
            _memoryView = memoryView ?? throw new ArgumentNullException(nameof(memoryView));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        public ITelephone Create()
        {
            return new Telephone(_telephoneView, _memory, _memoryView);
        }
    }
}