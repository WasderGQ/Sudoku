using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    
}
public class Keyboard : MonoBehaviour 
{
    [SerializeField] private List<Button> _myButtons;
    [SerializeField] private KeyboardKey _selectedKeyboardKey;
    [SerializeField] private List<MB_Zone> _selectedZones;
    [SerializeField] private Board _board;



    public void init()
    {
       

    }
    
    public void SaveZoneToList(MB_Zone zone)
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
