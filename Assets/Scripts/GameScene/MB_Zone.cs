
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MB_Zone : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private int _parselID;
    [SerializeField] private int _myValue;
    [SerializeField] private List<int> _possibleValues;
    [SerializeField] private Button _button;

    private int _changedMyValue
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
    
    
    public void init()
    {
        WriteParsel();
        EventStarter();
    }
   
    void EventStarter()
    {

        _button.onClick.AddListener(RandomlyGivePossibleValue);


    }

    #region Publics
    public void WriteValue(int givenvalue)
    {
        _changedMyValue = givenvalue;
    }

    public int ReadValue()
    {
        return _myValue;

    }

    /*public void WriteId(int id) 
    { 
    
    _id = id;
    
    }*/
    public void WriteParsel()
    {
        //_parsel = Parsen;
        _parselID=GetComponentInParent<MB_Parsel>().ReadParselID();
        
    }

    public int GetMyParsel()
    {
        return _parselID;
    }
 
    
    public void RandomlyGivePossibleValue()
    {

        WriteValue(_possibleValues[UnityEngine.Random.Range(0, _possibleValues.Count)]);

    }

    public void RemoveMyValueFromPossibleValues()
    {
        if (IsThereMyValueInPossibleValue())
            _possibleValues.Remove(_myValue);
    }
    #endregion




    #region Privates

    private void RefreshText(int Newvalue)
    {

        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text=Newvalue.ToString();
        Debug.Log(Newvalue.ToString());

    }
    private bool IsThereMyValueInPossibleValue()
    {
        foreach (var value in _possibleValues)
        {
            if (value == _myValue)
                return true;


        }

        return false;
    }

    #endregion


}