using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Board : MonoBehaviour
{

    [SerializeField] private MB_Parsel[] _parsels; 

    void RandomlyAddValue()
    {
        foreach (var parsel in _parsels) 
        { 
        foreach (var zone in parsel._zones)
            {
                zone.RandomlyGiveValue();

            }
        
        
        }





    }




}
