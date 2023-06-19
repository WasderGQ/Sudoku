using UnityEngine;
using WasderGQ.Sudoku.Generic;

namespace WasderGQ.Sudoku.BetweenScene
{
    public class AppSettings 
    {
        public void InIt()
        {
            OnAwakeSetScreenSettings();
            
        }

        private void OnAwakeSetScreenSettings()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }

    }
}



