using UnityEngine;

namespace Core.GameFlow
{
    public class GameFlowStrap
    {
        public readonly GameFlowEvent GameStart;
        public readonly GameFlowEvent GameFailed;
        
        public GameFlowStrap(GameFlowEvent gameStart, GameFlowEvent gameFailed)
        {
            GameStart = gameStart;
            GameFailed = gameFailed;
        }
    }
}
