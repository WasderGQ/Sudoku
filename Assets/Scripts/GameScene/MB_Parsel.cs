using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MB_Parsel : MonoBehaviour
{
    [SerializeField] public MB_Zone[] _zones;
    [SerializeField] private int _myparselID;
    public void init()
    {
        initZones();
       // GiveParsenAndIDToZones();
        
    }

    private void initZones()
    {

        foreach (var zone in _zones)
        {
            zone.init();

        }


    }
    /*private void GiveParsenAndIDToZones()
    {
        
        int counter = 0;
        foreach(var zone in _zones) 
        { 
        zone.WriteId(counter);
        counter++;
        zone.WriteParsel(_myparselID);

            
        }
        Debug.Log("Zonelara Id ve parselleri verildi");

    }*/

    public int ReadParselID()
    {
        return _myparselID;
    }
    















   /* public void RandomlyFillZones()
    {
        foreach (var zone in _zones) 
        {
            zone.RandomlyGiveValue();
        }





    }*/




}