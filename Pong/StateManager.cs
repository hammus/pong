using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public enum GameState { PLAYING, PAUSED }
    public static class StateManager
    {

        public static bool Playing
        {
            get
            {
                return StateManager.GameState == GameState.PLAYING;
            }
        }

        public static bool Paused
        {
            get
            {
                return StateManager.GameState == GameState.PAUSED;
            }
        }

        private static GameState GameState = GameState.PAUSED;
        

        public static void Play()
        {
            StateManager.GameState = GameState.PLAYING;
        }

        public static void Pause()
        {
            StateManager.GameState = GameState.PAUSED;
        }

        public static GameState GetState()
        {
            return StateManager.GameState;
        }

    }
}
