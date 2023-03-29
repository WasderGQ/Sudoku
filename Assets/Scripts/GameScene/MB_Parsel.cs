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
       
        
    }

    private void initZones()
    {

        foreach (var zone in _zones)
        {
            zone.init();

        }
        Debug.Log("All Zones In ited XD "+ _myparselID);

    }


    





    public int ReadParselID()
    {
        return _myparselID;
    }
    



}
