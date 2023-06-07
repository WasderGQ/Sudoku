using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MB_Zone : MonoBehaviour
{
    
    
    
   
     public List<int> ID { get; private set; }
     public int MyValue { get; private set; }
     [field:SerializeField] public int MyParselID { get; private set;}

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
        
        
        
    }

    public void DoClickAnimation()
    {
        
        
        
        
    }

    public void DoUnSelectedAnimation()
    {
        
        
        
        
    }
    
    public void WriteValue(int givenvalue)
    {
        _setMyValue = givenvalue;
    }


    private void RefreshText(int value)
    {
        
    }


    

    

}
