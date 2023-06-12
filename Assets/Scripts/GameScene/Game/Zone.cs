using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WasderGQ.Sudoku.Utility;

public class Zone : MonoBehaviour
{
     private List<int> _possibleValues;
     [field:SerializeField,LockVariableOnEditor] public int[] ZoneID { get; private set; }
     [field:SerializeField,LockVariableOnEditor] public int[] MyParselID { get; private set;}
     [field:SerializeField,LockVariableOnEditor] public int MyValue { get; private set; }
     [SerializeField] private Image _myImage;
     [SerializeField] private Color _defaultColor;
     
     
     
     private int _setMyValue //when value change trigger RefreshText func. #Property
     {
        get { return MyValue; }
        set
        {
            if (MyValue == value) return;
            if (MyValue != value) 
            {
                RefreshText(value);
                MyValue = value;

            }

        }
    }
    
    public void init()
    {
        _defaultColor = _myImage.color;
        Debug.Log($"COLOR RGB : {_defaultColor.r} , {_defaultColor.g} , {_defaultColor.b}");
        ZoneID = new int[2];
        MyParselID = new int[2];
    }

    public void RemoveValueFromPossibleValues(int value)
    {
        if (_possibleValues.Contains(value))
        {
            _possibleValues.Remove(value);
        }
        else
        {
            Debug.LogError("Possible value list doesn't contain "+ value);
        }
    }

    public List<int> GetPossibleValueList()
    {
        return _possibleValues;
    }
    
    
    public void DoClickAnimation()
    {
        _myImage.color = Color.green;
    }

    public void DoUnSelectedAnimation()
    {
        _myImage.color = _defaultColor;
    }
    
    public void WriteValue(int givenvalue)
    {
        _setMyValue = givenvalue;
    }

    public void SetParselID(int[] parselID)
    {
        

    }

    private void RefreshText(int value)
    {
        
    }


    

    

}
