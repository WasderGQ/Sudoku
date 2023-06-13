using System.Collections.Generic;
using UnityEngine;
using WasderGQ.Sudoku.AIs;
using WasderGQ.Sudoku.Scenes.GameScene.Game;
using WasderGQ.Sudoku.Scenes.GameScene.InputModuls;
using WasderGQ.Sudoku.Scenes.MainMenuScene;

namespace WasderGQ.Sudoku.Scenes.GameScene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private SO_GameMode _gameMode;
        [SerializeField] private List<Board> _boardList;
        [SerializeField] private MapCreater _botMap;
        [SerializeField] private int _currentlySelectedBoard;
        [SerializeField] private Keyboard _keyboard;
        [SerializeField] private Canvas _canvas;


        private void Start()
        {
            init();
        }

        private void init()
        {
            //SetMainCameraToCanvas();
            GetCurrentBoard();
            GameBoardOpener();
            BoardInIt();
            KeyboardInIt();
           
            
        }

        private void SetMainCameraToCanvas()
        {
            _canvas.worldCamera = Camera.main;
        }

        private void BoardInIt()
        {
            _boardList[_currentlySelectedBoard].init();
        }
        
        private void KeyboardInIt()
        {
            _keyboard.init();
        }

        private void GetCurrentBoard()
        {
            _currentlySelectedBoard = (int)_gameMode.GameBoards;
        }

        void GameBoardOpener()
        {
            _keyboard.gameObject.SetActive(true);
            _boardList[_currentlySelectedBoard].gameObject.SetActive(true);
        }






    }
}
