
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MB_Zone : MonoBehaviour
{
    [SerializeField] private List<int> _id;
    [SerializeField] private int _parselID;
    [SerializeField] private int _myValue;
    [SerializeField] private List<int> _possibleValues;
    [SerializeField] private Button _button;
   
     public List<int> ID { get => _id; }
     public int MyValue { get => _myValue; }
     public int MyParselID { get => _parselID; }
        
     public List<int> PossibleValues { get => _possibleValues; }

    private int _changedMyValue //when value change trigger RefreshText func. #Property
    {
        get { return _myValue; }
        set
        {
            if (_myValue == value) return;
            if (_myValue != value) 
            {
                RefreshText(value);
                _myValue = value;

            }

        }
    }
    
    

    

    #region Publics

    public void init()
    {
        
        
        
    }

    


    public MB_Zone SelectedZone()
    {
        return this;
    }


    public void WriteValue(int givenvalue)
    {
        _changedMyValue = givenvalue;
    }


    public void WriteParselID(int parselID)
    {

        _parselID = parselID;
        
    }


    public void RemoveParameterValueFromPossibleValueList(int GivenValue)
    {
       
            _possibleValues.Remove(GivenValue);
    }

    public void ReadPossiblyValuesToConsole()
    {
        foreach (int value in _possibleValues)
        { Debug.Log(_id + " : " + value); }
    }

    #endregion

    #region Privates

    private void RefreshText(int Newvalue)
    {

        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text=Newvalue.ToString();
        //Debug.Log(Newvalue.ToString());

    }
    

    #endregion


}
