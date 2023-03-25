using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Zone : MonoBehaviour
{
    [SerializeField] private int _myValue;
    
    public void WriteValue(int value)
    {
        _myValue = value;


    }

    public int ReadValue()
    {
        return _myValue;

    }

    public void RandomlyGiveValue()
    {
        _myValue=Random.Range(1,9);


    }



}
