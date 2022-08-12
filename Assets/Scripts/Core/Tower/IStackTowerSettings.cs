namespace Core.Tower
{
    public interface IStackTowerSettings
    {
        int InitialBlocksCount { get; }
        float BlockHeight { get; }
    }
}