using Assets.Scripts.GameScene;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Assets.Scripts.GameScene.PossibleValues;

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
        

    } //Init Zones Insýde This Parsel

    

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
