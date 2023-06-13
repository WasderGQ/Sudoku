using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WasderGQ.Sudoku.Scenes.GameScene.Game;
using WasderGQ.Sudoku.Scenes.GameScene.Game.Boards;

namespace WasderGQ.Sudoku.Scenes.GameScene.InputModuls
{
    public class Keyboard : MonoBehaviour 
    {
        [SerializeField] private List<Button> _myButtons;
        [SerializeField] private KeyboardKey _selectedKeyboardKey;
        [SerializeField] private List<Zone> _selectedZones;
        [FormerlySerializedAs("_board")] [SerializeField] private Boardx9 boardx9;



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

