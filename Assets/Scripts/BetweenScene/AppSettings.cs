using Generic;
using UnityEngine;

namespace WasderGQ.Sudoku.BetweenScene
{
    public class AppSettings : Singleton<AppSettings>
    {
        protected override void OnAwake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }
    

    }
}



