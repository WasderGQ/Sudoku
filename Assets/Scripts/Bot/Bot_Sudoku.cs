using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SudokuCreater
{
    private MB_Zone[,] _zones;
    private MB_Parsel[] _parsels;
    
    
   
    public SudokuCreater(MB_Zone[,] zones, MB_Parsel[] parsels)
    {

        _zones = zones;
        _parsels = parsels;
        
        

    }

    
  


    public async void SudokuSolverStart()
    {
        Debug.Log("Bot Started");
        await GiveRandomlyValueAllZones();
        Debug.Log("All Zones Filled");
       //await IsAllZoneValueTrue();
        Debug.Log("All Zones True");
    }


    private async Task<bool> IsAllZoneValueTrue()
    {

        for (int row = 0; row <= _zones.GetLength(0); row++)
        {
            for (int colomb = 0; colomb <= _zones.GetLength(1); colomb++)
            {

                

                while (await IsThereSameValueInRow(row, colomb) || await IsThereSameValueInColomb(row, colomb) || await IsThereSameValueInParsel(row, colomb))
                {

                   await RandomlyAddNewValueToZone(row, colomb);

                }

            }
        }

        return true;
    }


    private async Task<bool> IsThereSameValueInRow(int row, int colomb)
    {
        for (int colombcount = 0; colombcount <= _zones.GetLength(1); colombcount++)
        {
            if (_zones[row, colomb].ReadValue() == _zones[row, colombcount].ReadValue())
            { return true; }

        }
        return false;
    }


    private async Task<bool> IsThereSameValueInColomb(int row, int colomb)
    {

        for (int rowcount = 0; rowcount <= _zones.GetLength(1); rowcount++)
        {
            if (_zones[row, colomb].ReadValue() == _zones[row, rowcount].ReadValue())
            { return true; }

        }
        return false;


    }

    private async Task<bool> IsThereSameValueInParsel(int row, int colomb)
    {
        List<MB_Zone> myparselzones = new List<MB_Zone>();
        foreach (var item in _parsels[_zones[row, colomb].GetMyParsel()]._zones)
        {
            myparselzones.Add(item);
        }

        myparselzones.Remove(_zones[row, colomb]);

        foreach (var item in myparselzones)
        {
            if (item.ReadValue() == _zones[row, colomb].ReadValue())
            { return true; }
        }




        return false;
    }

    async Task<bool> RandomlyAddNewValueToZone(int row, int colomb)
    {
        _zones[row, colomb].RandomlyGivePossibleValue();
       
        return true;

    }


    

    async Task<bool> GiveRandomlyValueAllZones()
    {
        for (int row = 0; row <= _zones.GetLength(0); row++)
        {
            for (int colomb = 0; colomb < _zones.GetLength(1); colomb++)
            {
                
                
               /* while(await AmISameWithAnyMyRowZone(row,colomb) && await AmISameWithAnyMyColombZone(row, colomb) && await AmISameWithAnyMyParselZone(row, colomb))
                {
                    _zones[row, colomb].RemoveMyValueFromPossibleValues();
                    _zones[row,colomb].RandomlyGivePossibleValue();


                }*/
            }
        }
        
        return true;
        
        
        
        
        
        
        
        
        
        
        
        
        /*
        foreach (var item in _zones)
        {
            item.WriteValue(UnityEngine.Random.Range(1, 9));
        }
        return true;
        */


    }

    async Task<bool> AmISameWithAnyMyRowZone(int row,int colomb)
    {
        
        for (int colombcount = 0; colombcount <= _zones.GetLength(0); colombcount++)
        {
            //Debug.Log("Benimle ayný olan deðeri satýrda arýyorum " + _zones[row, colomb]);
            if (!_zones[row, colomb] == _zones[row,colombcount])
            {
                if (_zones[row, colomb].ReadValue() == _zones[row, colombcount].ReadValue())
                { return true; }
                
            }
            
            
        }

        return false;

    }
    async Task<bool> AmISameWithAnyMyColombZone(int row, int colomb )
    {
        Debug.Log("Benimle ayný olan deðeri sütunda arýyorum"+ _zones[row, colomb]);
        for (int rowcounter = 0; rowcounter <= _zones.GetLength(0); rowcounter++)
        {
            if (!_zones[row, colomb] == _zones[rowcounter, colomb])
            {
                if (_zones[row, colomb].ReadValue() == _zones[rowcounter, colomb].ReadValue())
                { return true; }

            }


        }
        return false;

    }


    async Task<bool> AmISameWithAnyMyParselZone(int row, int colomb)
    {
        Debug.Log("Benimle ayný olan deðeri parselde arýyorum" + _zones[row, colomb]);
        MB_Parsel currentzoneinparsel = _parsels[_zones[row, colomb].GetMyParsel()];
        foreach (var zone in currentzoneinparsel._zones)
        {
            if (!_zones[row, colomb] == zone)
            {
                if (_zones[row, colomb].ReadValue() == zone.ReadValue())
                { return true; }

            }
        }
        
        return false;


    }

    //async Task<bool> AmISame()
    
}
