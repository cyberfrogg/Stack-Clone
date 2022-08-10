using UnityEngine;

namespace Core.GameFlow
{
    public class GameFlowStrap
    {
        public readonly GameFlowEvent GameStart;
        
        public GameFlowStrap(GameFlowEvent gameStart)
        {
            GameStart = gameStart;
        }
    }
}
