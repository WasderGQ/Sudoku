using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WasderGQ.Sudoku.BetweenScene;
using WasderGQ.Sudoku.Generic;

namespace WasderGQ.Sudoku
{
    public class OnAwakePrepareApplication : Singleton<OnAwakePrepareApplication>
    {
        [SerializeField] private AppSettings _appSettings;
        private void Awake()
        {
            SetVariable();
            InIt();
        }

        private void SetVariable()
        {
            _appSettings = new AppSettings();

        }
        
        
        private void InIt()
        {
            _appSettings.InIt(); 
        }
        
    }
}
