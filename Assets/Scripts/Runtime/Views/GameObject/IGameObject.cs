namespace NotEnoughMemory.Model
{
    public interface IGameObject
    {
        bool IsActive { get; }

        void Destroy();

        void Enable();

        void Disable();
    }
}