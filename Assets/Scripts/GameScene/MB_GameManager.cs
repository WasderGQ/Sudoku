using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_GameManager : MonoBehaviour
{
   [SerializeField] private SO_GameMode _gameMode;
   [SerializeField] private List<MB_Board> _boardList;
   [SerializeField] private SudokuCreater _bot_sudoku;
   [SerializeField] private int _currentlySelectedBoard;
  
    

   
    private void Start()
    {
        init();
        _boardList[_currentlySelectedBoard].init();

    }
    private void init()
    {
        GetCurrentBoard();
        GameBoardOpener();
        


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
