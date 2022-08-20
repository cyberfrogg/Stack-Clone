namespace Core.Tower.Blocks
{
    public struct BlockPlaceResult
    {
        public readonly bool IsSuccess;

        public BlockPlaceResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}