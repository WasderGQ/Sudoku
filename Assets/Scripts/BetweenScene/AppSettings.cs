using System;
using System.Collections;
using System.Collections.Generic;
using Generic;
using UnityEngine;

public class AppSettings : Singleton<AppSettings>
{
    protected override void OnAwake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
    }
    

}
