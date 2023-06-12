using UnityEngine;

namespace WasderGQ.Sudoku.MainMenuScene
{
    [CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameMode", order = 1)]
    public class SO_GameMode : ScriptableObject
    {

        [field:SerializeField]public GameBoardsEnum GameBoardsEnum { get; private set; }

        public void SetGamemode3x3()
        {
            GameBoardsEnum = GameBoardsEnum.x3;
        }
   
        public void SetGamemode6x6()
        {
            GameBoardsEnum = GameBoardsEnum.x6;
        }
    
        public void SetGamemode9x9() 
        {
            GameBoardsEnum = GameBoardsEnum.x9;
        }
    
        public void SetGamemode12x12()
        {
            GameBoardsEnum = GameBoardsEnum.x12;
        }
        

        private void GameStart()
        {
        
        
        
        

        }
        
    }
}

