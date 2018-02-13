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

        private static int _scoreP1 = 0;
        private static int _scoreP2 = 0;
        public static int ScoreP1
        {
            get
            {
                return _scoreP1;
            }
        }

        public static int ScoreP2
        {
            get
            {
                return _scoreP2;
            }
        }

        public static void GoalP1()
        {
            _scoreP1++;
        }

        public static void GoalP2()
        {
            _scoreP2++;
        }


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
