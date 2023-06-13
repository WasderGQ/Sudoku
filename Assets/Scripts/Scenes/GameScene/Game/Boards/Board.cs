using UnityEngine;
using WasderGQ.Sudoku.AIs;
using WasderGQ.Sudoku.Enums;
using WasderGQ.Sudoku.Scenes.MainMenuScene;

namespace WasderGQ.Sudoku.Scenes.GameScene.Game.Boards
{
    public abstract class Board : MonoBehaviour
    {
        protected MapCreater _mapCreater;
        public readonly GameBoards GameBoards;
        public Parsel[] Parsels { get; }
        public Zone[,] Zones { get; }


        public virtual void InIt()
        {
            
        }

        protected virtual void ParselsInIt()
        {
            
        }

        protected virtual void AddMapCreater()
        {
            try 
            {
                _mapCreater = new MapCreater(Parsels,Zones);
            }
        
            catch
            {
                Debug.Log("Map Creater can't create on Board class !!!!");
            }
            
        }
        
        protected async virtual void StartMapCreater()
        {
           await _mapCreater.Start();
        }

        protected virtual void ConvertParselZonesToZones()
        {
            
        }
        
    }
}
