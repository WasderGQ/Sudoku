using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using WasderGQ.Sudoku.AIs;
using WasderGQ.Sudoku.Enums;
using WasderGQ.Sudoku.Scenes.MainMenuScene;
using WasderGQ.Utility.List_Array_Etc;

namespace WasderGQ.Sudoku.Scenes.GameScene.Game.Boards
{
    public abstract class Board : MonoBehaviour
    {
        [SerializeField] protected SolvedSudokuCreater SolvedSudokuCreater;
        [SerializeField] protected Parsel[] _parsels;
        [SerializeField] protected Zone[,] _zones;
        
        public Parsel[] Parsels { get => _parsels; }
        public Zone[,] Zones { get => _zones; }
        
        public virtual void InIt()
        {
            
        }

        protected virtual void ParselsInIt()
        {
            foreach (var parsel in _parsels)
            {
                parsel.init();
            } 
        }
       
        protected virtual void AddMapCreater()
        {
            try 
            {
                SolvedSudokuCreater = new SolvedSudokuCreater(Parsels,Zones);
            }
        
            catch
            {
                Debug.Log("Map Creater can't create on Boardx9 class !!!!");
            }
        
        }
        
        protected virtual async void StartMapCreater()
        {
            bool done = await SolvedSudokuCreater.Start();
        }

        protected virtual void ConvertParselZonesToZones()
        {
            
        }
        
        protected virtual void SetZonesID()
        {
            foreach (var zone in _zones)
            {
                int[] indexs = _zones.FindIndex(zone); 
                zone.SetZoneID(indexs);
            }
        }
        protected virtual void MakeZonesDefault()
        {
            foreach (var parsel in _parsels)
            {
                foreach (var zone in parsel.ZonesInParsel)
                {
                    zone.SetTrueValue(zone.MyValue);
                    zone.SetMyValueDefault();
                }
            }
        }
    }
}
