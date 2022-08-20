using UnityEngine;

namespace Core.GameFlow
{
    public class GameFlowStrap
    {
        public readonly GameFlowEvent GameStart;
        public readonly GameFlowEvent GameFailed;
        public readonly GameFlowEvent GameRestart;
        
        public GameFlowStrap(GameFlowEvent gameStart, GameFlowEvent gameFailed, GameFlowEvent gameRestart)
        {
            GameStart = gameStart;
            GameFailed = gameFailed;
            GameRestart = gameRestart;
        }
    }
}
