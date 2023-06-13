using System.Collections.Generic;
using UnityEngine;
using WasderGQ.Sudoku.AIs;
using WasderGQ.Sudoku.Scenes.GameScene.Game;
using WasderGQ.Sudoku.Scenes.GameScene.Game.Boards;
using WasderGQ.Sudoku.Scenes.GameScene.InputModuls;
using WasderGQ.Sudoku.Scenes.MainMenuScene;

namespace WasderGQ.Sudoku.Scenes.GameScene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private SO_GameMode _gameMode;
        [SerializeField] private List<Boardx9> _boardList;
        [SerializeField] private MapCreater _mapCreater;
        [SerializeField] private int _currentlySelectedBoard;
        [SerializeField] private Keyboard _keyboard;


        private void Start()
        {
            init();
        }

        private void init()
        {
            GetCurrentBoard();
            GameBoardOpener();
            BoardInIt();
            KeyboardInIt();
           

        }
        

        private void BoardInIt()
        {
            _boardList[_currentlySelectedBoard].InIt();
        }
        
        private void KeyboardInIt()
        {
            _keyboard.init();
        }

        private void GetCurrentBoard()
        {
            _currentlySelectedBoard = (int)_gameMode.GameBoards;
        }

        private void GameBoardOpener()
        {
            _keyboard.gameObject.SetActive(true);
            _boardList[_currentlySelectedBoard].gameObject.SetActive(true);
        }

        





    }
}
