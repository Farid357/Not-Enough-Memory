using System;
using NotEnoughMemory.Storage;

namespace NotEnoughMemory.UI
{
    public sealed class DeleteAllSavesButton : IButton
    {
        private readonly ISaveStorages _saveStorages;

        public DeleteAllSavesButton(ISaveStorages saveStorages)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public void Press()
        {
            if (_saveStorages.HasSaves())
                _saveStorages.DeleteAllSaves();
        }
    }
}