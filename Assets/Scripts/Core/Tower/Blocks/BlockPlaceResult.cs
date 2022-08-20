namespace Core.Tower.Blocks
{
    public struct BlockPlaceResult
    {
        public readonly bool IsSuccess;
        public readonly ITowerBlock Block;

        public BlockPlaceResult(bool isSuccess, ITowerBlock block)
        {
            IsSuccess = isSuccess;
            Block = block;
        }
    }
}