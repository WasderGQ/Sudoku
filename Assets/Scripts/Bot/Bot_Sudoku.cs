using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class SudokuCreater
{
    private MB_Zone[,] _processedZones;
    private MB_Parsel[] _processedParsels;
    private List<int> _firstFillParsels;


    public SudokuCreater(MB_Zone[,] zones, MB_Parsel[] parsels)
    {

        _processedZones = zones;
        _processedParsels = parsels;



    }

    ///  ----<Region How to Work>----
    /// Metod parsel pasel init()
    /// first section 0,4,8
    /// second section 2,6
    ///  third section 1,5
    /// Fourth section 3,7
    /// Finally Done
    ///     ----<EndRegion>---





    public async Task<bool> SudokuSolverStart()
    {
        bool task0 = await FillParsels();
        bool task1 = await FillBoard();
       if (!task0 && !task0) { Debug.Log("FillVoard Failed"); return false; }
        return true;
    }


    private async Task<bool> FillParsels()
    {
        bool totalTask = false;
        await SetParameterValurToAllZones(0);
        while (!totalTask)
        {

            bool task0 = await FillZonesWithValueInParsel(_processedParsels, 0);
            bool task1 = await FillZonesWithValueInParsel(_processedParsels, 4);
            bool task2 = await FillZonesWithValueInParsel(_processedParsels, 8);
            
            totalTask = task0 && task1 && task2 ;

        }

        return true;
    }









    async Task<bool> FillBoard()
    {
       
            int counter = default(int);
             
            do
            {
                counter++;
                foreach (var zone in _processedZones)
                {

                   await FillZone(zone);
                    Task.Delay(1);
                }
            
            
            Debug.Log($"Tried Count : {counter} ");

            if (counter == 100)
                {

                Debug.Log("I tried 100 times but I cant fill board ");
                return false;
                }
            }
            while (!IsAllZonesFilled());

        return true;
    }

        
    private async Task<bool> RowToZero(MB_Zone zone)
    {
        for (int i = 0; i < _processedZones.GetLength(0); i++)
        {
            _processedZones[i, zone.ID[1]].WriteValue(0);
        }
        return true;

    }
    private async Task<bool> ColombToZero(MB_Zone zone)
    {
        for (int i = 0; i < _processedZones.GetLength(1); i++)
        {
            _processedZones[zone.ID[0], i].WriteValue(0);
        }

        return true;
    }
    private async Task<bool> ParselToZero(MB_Zone zone)
    {
        foreach (MB_Zone z in _processedParsels[zone.MyParselID].ZonesInParsel)
        {
            z.WriteValue(0);
        }
        return true;


    }






    private async Task<bool> SetParameterValurToAllZones(int value)
    {
        foreach (var zone in _processedZones)
        {
            zone.WriteValue(value);




        }

        return true;


    }
    private async Task<List<MB_Zone>>  NoFilledZonesCollector()
    {
        List<MB_Zone> zones = new List<MB_Zone>();
        foreach (var zone in _processedZones)
        {
            if(zone.MyValue == 0) 
            {
                zones.Add(zone);
                 
            
            
            }
            

        }
        return zones;



    }
   private bool IsAllZonesFilled()
    {

        foreach(var zone in _processedZones)
        {

            if (zone.MyValue == 0)
            {

                return false;
            }


        }
        return true;


    }








    private async Task<bool> FillZone(MB_Zone zone)
    {
            if (zone.MyValue == 0)
            {
                List<int> possibleValues = GetPossibleValues(zone);
                ShuffleList(possibleValues);

                foreach (int value in possibleValues)
                {
                    if (IsValid(zone, value))
                    {
                        zone.WriteValue(value) ;
                        return true;
                        

                        
                    }
                    zone.WriteValue(0);
                }

                return false;
            }
        
        return true;
    }
       
    

    private List<int> GetPossibleValues(MB_Zone zone)
    {
        List<int> possibleValues = new List<int>();

        for (int i = 1; i <= 9; i++)
        {
            possibleValues.Add(i);
        }

        foreach (MB_Zone z in _processedZones)
        {
            if (z.ID[0] == zone.ID[0] || z.ID[1] == zone.ID[1] || z.MyParselID == zone.MyParselID)
            {
                if (possibleValues.Contains(z.MyValue))
                {
                    possibleValues.Remove(z.MyValue);
                }
            }
        }

        return possibleValues;
    }

    private bool IsValid(MB_Zone zone, int value)
    {
        for (int i = 0; i < 9; i++)
        {
            if (_processedZones[i, zone.ID[1]].MyValue == value || _processedZones[zone.ID[0], i].MyValue == value)
            {
                return false;
            }
        }

        foreach (MB_Zone z in _processedParsels[zone.MyParselID].ZonesInParsel)
        {
            if (z.MyValue == value)
            {
                return false;
            }
        }

        return true;
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }


 


  public async Task<bool> FillZonesWithValueInParsel(MB_Parsel[] mB_Parsels, int parselID)
  {
      try
      {
          foreach (var mainzone in mB_Parsels[parselID].ZonesInParsel)
          {

              bool fillZonesWithValueInParsel = await RandomlyGivenPossiblyValue(mainzone);
              await GivenZoneValueRemovingOnRow(mainzone, _processedZones);
              await GivenZoneValueRemovingOnColomb(mainzone, _processedZones);
              await GivenZoneValueRemovingOnParsel(mainzone, mB_Parsels);




          }

          Debug.Log($"Parsel[{parselID}] Done");

          return true;
      }

      catch
      {
          Debug.Log($"Parsel[{parselID}] failed to finish!!!!");

          return false;
      }

  }


  private async Task<bool> GivenZoneValueRemovingOnRow(MB_Zone mB_Zone, MB_Zone[,] mB_Zones)
  {
      for (int i = 0; i < 9; i++)
      {
          mB_Zones[mB_Zone.ID[0], i].RemoveParameterValueFromPossibleValueList(mB_Zone.MyValue);
      }

      return true;
  }
  private async Task<bool> GivenZoneValueRemovingOnColomb(MB_Zone mB_Zone, MB_Zone[,] mB_Zones)
  {
      for (int i = 0; i < 9; i++)
      {
          mB_Zones[i, mB_Zone.ID[1]].RemoveParameterValueFromPossibleValueList(mB_Zone.MyValue);
      }
      return true;

  }
  private async Task<bool> GivenZoneValueRemovingOnParsel(MB_Zone mB_Zone, MB_Parsel[] mB_Parsels)
  {
      foreach (var zone in mB_Parsels[mB_Zone.MyParselID].ZonesInParsel)
      {
          zone.RemoveParameterValueFromPossibleValueList(mB_Zone.MyValue);
      }
      return true;

  }

  private async Task<bool> RandomlyGivenPossiblyValue(MB_Zone mB_Zone)
  {

      mB_Zone.WriteValue(mB_Zone.PossibleValues[UnityEngine.Random.Range(0, mB_Zone.PossibleValues.Count)]);
      return true;
  }
















        }



   
























/*










































































    #region skip this part now

    /*private async Task<bool> IsAllZoneValueTrue()
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

    }*/

    



    



    /* 

     private async Task<bool> GiveRandomlyValueAllZones()
        {
            await RandomlyFillZoneValues();

            for (int row = 0; row <= _zones.GetLength(0); row++)
            {
                for (int colomb = 0; colomb < _zones.GetLength(1); colomb++)
                {


                    while(await IsAnySameValue(row,colomb))
                    {
                        _zones[row, colomb].RandomlyGiveValueFromPossibleValueList();
                        _zones[row, colomb].RemoveMyValueFromPossibleValueList();



                    }
                }
            }

            return true;

        }



        private async Task<bool> IsAnySameValue(int row , int colomb) 
        {
            bool RowRole = await AmISameWithAnyMyRow(row, colomb);
            bool ColombRole = await AmISameWithAnyMyColomb(row, colomb);
            bool ParselRole = await AmISameWithAnyMyParsel(row, colomb);
            if (RowRole && ColombRole && ParselRole)
            { return true; }
            return false;


        }





        private async Task<bool> RandomlyFillZoneValues()
        {
            foreach (var zone in _zones)
            {
                zone.RandomlyGiveValueFromPossibleValueList();
                zone.RemoveMyValueFromPossibleValueList();



            }

            return true;

        }



        private async Task<bool> AmISameWithAnyMyRow(int row,int colomb)
        {

            for (int colombcount = 0; colombcount <= _zones.GetLength(1); colombcount++)
            {

                if (_zones[row, colomb] != _zones[row,colombcount])
                {
                    Debug.Log("Colomb Control : Parsel: " + _zones[row, colombcount].GetMyParsel() + " ZoneID : " + _zones[row, colombcount].name + " Zone.Value : " + _zones[row, colombcount].ReadValue());

                    if (_zones[row, colomb].ReadValue() == _zones[row, colombcount].ReadValue())
                    { return true; }
                }
                else if(_zones[row, colomb] == _zones[row, colombcount])
                {
                    continue;


                }
            }

            return false;

        }
        private async Task<bool> AmISameWithAnyMyColomb(int row, int colomb )
        {  
            for (int rowcounter = 0; rowcounter <= _zones.GetLength(0); rowcounter++)
            {

                if (_zones[row, colomb] != _zones[rowcounter, colomb])
                {
                    Debug.Log("Row Control : Parsel: " + _zones[rowcounter, colomb].GetMyParsel() + " ZoneID : " + _zones[rowcounter, colomb].name + " Zone.Value : " + _zones[rowcounter, colomb].ReadValue());

                    if (_zones[row, colomb].ReadValue() == _zones[rowcounter, colomb].ReadValue())
                    { return true; }
                }
                else if (_zones[row, colomb] == _zones[rowcounter, colomb])
                {
                    continue;


                }

            }
            return false;

        }


        private async Task<bool> AmISameWithAnyMyParsel(int row, int colomb)
        {

            MB_Parsel currentzoneinparsel = _parsels[_zones[row, colomb].GetMyParsel()];
            foreach (var zone in currentzoneinparsel._zones)
            {

                if (!_zones[row, colomb] == zone)
                {
                    Debug.Log("Parsel Control : Parsel: " + zone.GetMyParsel() + " ZoneID : " + zone.name + " Zone.Value : " + zone.ReadValue());

                    if (_zones[row, colomb].ReadValue() == zone.ReadValue())
                    { return true; }

                }
                else if (_zones[row, colomb] == zone)
                {
                    continue;


                }
            }

            return false;


        }
       */








