using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WasderGQ.GameScene.Game;
using WasderGQ.Sudoku.GameScene.Game;

namespace WasderGQ.Sudoku.GameScene.InputModuls
{
    public class Keyboard : MonoBehaviour 
    {
        [SerializeField] private List<Button> _myButtons;
        [SerializeField] private KeyboardKey _selectedKeyboardKey;
        [SerializeField] private List<Zone> _selectedZones;
        [SerializeField] private Board _board;



        public void init()
        {
       

        }
    
        public void SaveZoneToList(Zone zone)
        {
            _selectedZones.Add(zone);
        }

        public void FillZoneWithValue(KeyboardKey key)
        {
            if (_selectedZones.Count > 0)
            {
                foreach (var zone in _selectedZones)
                {
                    zone.WriteValue(key.MyValue);
                    zone.DoUnSelectedAnimation();
                }
                _selectedZones.Clear();
            }
       
       
        
        
        }
    }
}

