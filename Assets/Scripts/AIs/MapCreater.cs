using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;
using WasderGQ.Sudoku.Scenes.GameScene.Game;
using WasderGQ.Sudoku.Scenes.GameScene.Game.Boards;
using WasderGQ.Sudoku.Utility;
using WasderGQ.Utility.List_Array_Etc;
using Random = UnityEngine.Random;

namespace WasderGQ.Sudoku.AIs
{
    public class MapCreater
    {
        private Zone[,] _processedZones;
        private Parsel[] _processedParsels;
        private List<int> _firstFillParsels;
        private int[] _choosableIndex = new[] { 0, 2 };


        public MapCreater(Parsel[] parsels,Zone[,] zones)
        {
            _processedZones = zones ;
            _processedParsels = parsels;
        }

        ///  ----<Region How to Work>----
        /// Metod Task<bool> Start() ///
        /// first step select parsel 0 or 2.
        /// second step filling chose parsel and opposite cornerside parsel (distance between 2 corner parsel : 6).
        /// third step this filled 2 corner parsel crossing 2 different cornel parsel this 2 parsel looking impossible value from filled parsels for its zones .
        /// fourth step this impossible value removing from possibleValues on zone.
        /// fifth step create zone list most possibleValue count to lowest possible value
        /// sixth step fill parsel's zone by created step fifth zone list
        ///
        ///
        ///
        ///
        ///
        ///
        /// Finally Done
        ///     ----<EndRegion>---

        public async Task<bool> Start()
        {
            FillCornerParsels();
            return true;
        }

        //step 1
        private void FillCornerParsels()
        {
            FillParsel(_processedParsels[0],false);
            FillParsel(_processedParsels[8],false);
            RemoveImpossibleValuesFromParselZones(_processedParsels[2]);
            RemoveImpossibleValuesFromParselZones(_processedParsels[6]);
            FillParsel(_processedParsels[2],true);
            FillParsel(_processedParsels[6],true);
        }
        
        private void RemoveImpossibleValuesFromParselZones(Parsel parsel)
        {
            foreach (var zone in parsel.ZonesInParsel)
            {
                for (int i = 0; i < _processedZones.GetLength(1); i++)
                {
                    if(zone.PossibleValueList.Contains(_processedZones[zone.ZoneID[0], i].MyValue))
                    {
                        zone.RemoveValueFromPossibleValues(_processedZones[zone.ZoneID[0], i].MyValue);
                    }
                }
                for (int i = 0; i < _processedZones.GetLength(0); i++)
                {
                    if (zone.PossibleValueList.Contains(_processedZones[i,zone.ZoneID[0]].MyValue))
                    {
                        zone.RemoveValueFromPossibleValues(_processedZones[i,zone.ZoneID[0]].MyValue);
                    }
                }
            }
            
        }

        private void FillParsel(Parsel parsel,bool startWithLowestPossibleValue)
        {
            if (startWithLowestPossibleValue == false)
            {
                foreach (var zone in parsel.ZonesInParsel)
                {
                    int valueIndex = Convert.ToInt32(Mathf.Floor(Random.Range(0,zone.PossibleValueList.Count-1)));
                    int value = zone.GetValueOnPossibleValueList(valueIndex);
                    zone.WriteValue(value);
                    parsel.ParselRemovePossibleValueOnZone(value);
                } 
            }
            else
            {
                parsel.ZonesInParsel.QuickSortArray<Zone>();
                foreach (var zone in parsel.ZonesInParsel)
                {
                    int valueIndex = Convert.ToInt32(Mathf.Floor(Random.Range(0,zone.PossibleValueList.Count-1)));
                    int value = zone.GetValueOnPossibleValueList(valueIndex);
                    zone.WriteValue(value);
                    parsel.ParselRemovePossibleValueOnZone(value);
                }
            }
        }

       
    }
}




