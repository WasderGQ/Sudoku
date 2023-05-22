using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
   [SerializeField] private SO_GameMode _gameMode;
   [SerializeField] private List<Board> _boardList;
   [SerializeField] private SudokuCreater _bot_sudoku;
   [SerializeField] private int _currentlySelectedBoard;
   [SerializeField] private Keyboard _keyboard;
    

   
    private void Start()
    {
        init();
        _boardList[_currentlySelectedBoard].init();

    }
    private void init()
    {
        KeyboardInIt();
        GetCurrentBoard();
        GameBoardOpener();
        


    }
    private void KeyboardInIt()
    {
        _keyboard.init();


    }
    
    private void GetCurrentBoard()
    {
      _currentlySelectedBoard = (int)_gameMode.TakeGameMode();
    }

    void GameBoardOpener()
    {
        _boardList[_currentlySelectedBoard].gameObject.SetActive(true);
    }
   
   
   



}
