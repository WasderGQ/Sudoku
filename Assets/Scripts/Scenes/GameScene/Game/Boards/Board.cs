using UnityEngine;
using UnityEngine.Serialization;
using WasderGQ.Sudoku.AIs;
using WasderGQ.Sudoku.Enums;
using WasderGQ.Sudoku.Scenes.MainMenuScene;

namespace WasderGQ.Sudoku.Scenes.GameScene.Game.Boards
{
    public abstract class Board : MonoBehaviour
    {
        
        public readonly GameBoards GameBoards;
        [SerializeField] protected MapCreater _mapCreater;
        public virtual Parsel[] Parsels { get; }
        public virtual Zone[,] Zones { get; }

       

        public virtual void InIt()
        {
            
        }

        protected virtual void ParselsInIt()
        {
            
        }
        protected virtual void SynchronizeVariableWithBaseClass()
        {
            
        }
        protected virtual void AddMapCreater()
        {
            
        }
        
        protected virtual async void StartMapCreater()
        {
           await _mapCreater.Start();
        }

        protected virtual void ConvertParselZonesToZones()
        {
            
        }
        protected virtual void SetZonesIDs(Zone[,] zones)
        {
            int counterI = 0;
            for (int i = 0; i < zones.GetLength(0); i++)
            {
                int counterJ = 0;
                for (int j = 0; j < zones.GetLength(1); j++)
                {
                    zones[i,j].SetZoneID(new []{counterI,counterJ});
                    counterJ++;
                }

                counterI++;
            }
        
        }
        
    }
}
