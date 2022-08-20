using System;

namespace Core.BlockPlacing
{
    public interface IBlockPlacerInput
    {
        event Action Pressed;
    }
}