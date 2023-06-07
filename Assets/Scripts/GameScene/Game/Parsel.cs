using System.Collections.Generic;
using UnityEngine;


public class MB_Parsel : MonoBehaviour
{
    [SerializeField] private MB_Zone[] _zonesInParsel;
    [SerializeField] private int _myparselID;
    [SerializeField] private List<int> _possiblevalues;


    public MB_Zone[] ZonesInParsel { get => _zonesInParsel;  }
    public void init() //Init Parsel
    {
        GiveMyIDToZones();
        initMyZones();
        PossibleValueInit();
   


    }
    


    private void initMyZones()
    {

        foreach (var zone in ZonesInParsel)
        {
            zone.init();

        }
        

    } //Init Zones Inside This Parsel

    

    public void GiveMyIDToZones()
    {
        foreach (var zone in ZonesInParsel)
        {
            zone.WriteParselID(_myparselID);

        }
    } //Parsel giving ID to zone
    
    void PossibleValueInit()
    {
        _possiblevalues = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9

        };


    }
    public int RandomlyGiveValueFromPossibleValueList()
    {


      return _possiblevalues[Random.Range(0, _possiblevalues.Count)];

    }

    public void RemoveGivenValueFormPossibleValueList(int givenvalue)
    {

        _possiblevalues.Remove(givenvalue);

    }
}
