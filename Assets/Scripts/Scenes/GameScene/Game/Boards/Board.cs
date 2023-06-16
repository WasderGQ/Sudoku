using System;
using System.Linq;
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
        [SerializeField] protected MapCreater _mapCreater;
        [SerializeField] protected Parsel[] _parselsList;
        [SerializeField] protected Zone[,] _zones;
        public Parsel[] Parsels { get => _parselsList; }
        public Zone[,] Zones { get => _zones; }
        
        public virtual void InIt()
        {
            
        }

        protected virtual void ParselsInIt()
        {
            foreach (var parsel in _parselsList)
            {
                parsel.init();
            } 
        }
       
        protected virtual void AddMapCreater()
        {
            try 
            {
                _mapCreater = new MapCreater(Parsels,Zones);
            }
        
            catch
            {
                Debug.Log("Map Creater can't create on Boardx9 class !!!!");
            }
        
        }
        
        protected virtual async void StartMapCreater()
        {
           await _mapCreater.Start();
        }

        protected virtual void ConvertParselZonesToZones()
        {
            
        }
        
        protected void SetZonesID()
        {
            foreach (var zone in _zones)
            {
                int[] indexs = _zones.FindIndex(zone); 
                zone.SetZoneID(indexs);
            }
        }
        
    }
}
