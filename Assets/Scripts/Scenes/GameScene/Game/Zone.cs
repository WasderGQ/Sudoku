using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WasderGQ.ThirdPartyUtility.DOTween.Modules;
using WasderGQ.Utility.List_Array_Etc;
using WasderGQ.Utility.UnityEditor;

namespace WasderGQ.Sudoku.Scenes.GameScene.Game
{
   public class Zone : MonoBehaviour ,IComparableObj
   {
     
     [SerializeField] private SpriteRenderer _myImage;
     [SerializeField] private TextMeshPro _text;
     [field:SerializeField,DisableValueChange] public int[] ZoneID { get; private set; }
     [field:SerializeField,DisableValueChange] public int[] ParselID { get; private set;}
     [field:SerializeField,DisableValueChange] public int MyValue { get; private set; }
     [field:SerializeField,DisableValueChange] public List<int> PossibleValueList { get; private set; }
     public int ComparableValue { get => PossibleValueList.Count; }
     
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
        ZoneID = new int[2];
        ParselID = new int[2];
    }

    private void SetPossiblyValuesOnStart()
    {
        PossibleValueList = new List<int>()
        {
            1,2,3,4,5,6,7,8,9
        };
    }

    public void RemoveValueFromPossibleValues(int value)
    {
        if (PossibleValueList.Contains(value))
        {
            PossibleValueList.Remove(value);
        }
        else
        {
            Debug.LogError("Possible value list doesn't contain "+ value);
        }
    }

    public int GetValueOnPossibleValueList(int valueIndex)
    {
        return PossibleValueList[valueIndex];
    }
    
    
    public void DoClickAnimation()
    {

        _myImage.DOColor(Color.cyan, 0.5f);

    }

    public void DoUnSelectedAnimation()
    {
        _myImage.DOColor(Color.white, 0.5f);
    }

    public bool ComparePossibleValue(int value)
    {
        if (PossibleValueList.Contains(value))
        {
            return true;
        }

        return false;
    }
    public void WriteValue(int givenvalue)
    {
        _setMyValue = givenvalue;
    }

    public void SetParselID(int[] parselID)
    {
        ParselID = parselID;
    }

    public void SetZoneID(int[] zoneID)
    {
        ZoneID = zoneID;
    }
    
    private void RefreshText(int value)
    {
        _text.text = value.ToString();
    }


    
   } 
}

