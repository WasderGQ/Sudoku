using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WasderGQ.Sudoku.Utility;
using TMPro;

namespace WasderGQ.GameScene.Game
{
   public class Zone : MonoBehaviour
{
     [SerializeField] private List<int> _possibleValues;
     [SerializeField] private Image _myImage;
     [SerializeField] private Color _defaultColor;
     [SerializeField] private TextMeshProUGUI _text;
     [field:SerializeField,LockVariableOnEditor] public int[] ZoneID { get; private set; }
     [field:SerializeField,LockVariableOnEditor] public int[] MyParselID { get; private set;}
     [field:SerializeField,LockVariableOnEditor] public int MyValue { get; private set; }
     
     
     
     
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
        SetPossiblyValuesOnStart();
        _defaultColor = _myImage.color;
        Debug.Log($"COLOR RGB : {_defaultColor.r} , {_defaultColor.g} , {_defaultColor.b}");
        ZoneID = new int[2];
        MyParselID = new int[2];
    }

    private void SetPossiblyValuesOnStart()
    {
        _possibleValues = new List<int>()
        {
            1,2,3,4,5,6,7,8,9
        };
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
        _myImage.color = Color.white;
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
        _text.text = value.ToString();
    }

} 
}

