namespace NotEnoughMemory.Model
{
    public interface IGameObjectWithTransform : IGameObject
    {
        ITransformData Transform { get; }
    }
}