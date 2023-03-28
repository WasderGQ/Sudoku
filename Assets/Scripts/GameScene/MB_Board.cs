using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MB_Board : MonoBehaviour
{

    [SerializeField] private MB_Parsel[] _parsels;
    [SerializeField] public MB_Zone[,] _mathZones;
    [SerializeField] private SudokuCreater _botSudoku;
    public void init()
    {
        InitParsels();
        FillMathZones();
        Debug.Log("All zones Saved Board");
        //AddSudokuBot();
        Debug.Log("Sudokubot added Board");
        //StartSudokuBot();
        
        

    }

    void FillMathZones()
    {
        _mathZones = new MB_Zone[,] 
        { { _parsels[0]._zones[0], _parsels[0]._zones[1], _parsels[0]._zones[2],/***/ _parsels[1]._zones[0], _parsels[1]._zones[1], _parsels[1]._zones[2],/***/ _parsels[2]._zones[0], _parsels[2]._zones[1], _parsels[2]._zones[2] },
          { _parsels[0]._zones[3], _parsels[0]._zones[4], _parsels[0]._zones[5],/***/ _parsels[1]._zones[3], _parsels[1]._zones[4], _parsels[1]._zones[5],/***/ _parsels[2]._zones[3], _parsels[2]._zones[4], _parsels[2]._zones[5] },
          { _parsels[0]._zones[6], _parsels[0]._zones[7], _parsels[0]._zones[8],/***/ _parsels[1]._zones[6], _parsels[1]._zones[7], _parsels[1]._zones[8],/***/ _parsels[2]._zones[6], _parsels[2]._zones[7], _parsels[2]._zones[8] },
          { _parsels[3]._zones[0], _parsels[3]._zones[1], _parsels[3]._zones[2],/***/ _parsels[4]._zones[0], _parsels[4]._zones[1], _parsels[4]._zones[2],/***/ _parsels[5]._zones[0], _parsels[5]._zones[1], _parsels[5]._zones[2] },
          { _parsels[3]._zones[3], _parsels[3]._zones[4], _parsels[3]._zones[5],/***/ _parsels[4]._zones[3], _parsels[4]._zones[4], _parsels[4]._zones[5],/***/ _parsels[5]._zones[3], _parsels[5]._zones[4], _parsels[5]._zones[5] },
          { _parsels[3]._zones[6], _parsels[3]._zones[7], _parsels[3]._zones[8],/***/ _parsels[4]._zones[6], _parsels[4]._zones[7], _parsels[4]._zones[8],/***/ _parsels[5]._zones[6], _parsels[5]._zones[7], _parsels[5]._zones[8] },
          { _parsels[6]._zones[0], _parsels[6]._zones[1], _parsels[6]._zones[2],/***/ _parsels[7]._zones[0], _parsels[7]._zones[1], _parsels[7]._zones[2],/***/ _parsels[8]._zones[0], _parsels[8]._zones[1], _parsels[8]._zones[2] },
          { _parsels[6]._zones[3], _parsels[6]._zones[4], _parsels[6]._zones[5],/***/ _parsels[7]._zones[3], _parsels[7]._zones[4], _parsels[7]._zones[5],/***/ _parsels[8]._zones[3], _parsels[8]._zones[4], _parsels[8]._zones[5] },
          { _parsels[6]._zones[6], _parsels[6]._zones[7], _parsels[6]._zones[8],/***/ _parsels[7]._zones[6], _parsels[7]._zones[7], _parsels[7]._zones[8],/***/ _parsels[8]._zones[6], _parsels[8]._zones[7], _parsels[8]._zones[8] },
        };
        

    }
    
    private void AddSudokuBot()
    {

        _botSudoku = new SudokuCreater(_mathZones,_parsels);



    }




    public void StartSudokuBot()
    {
        _botSudoku.SudokuSolverStart();
          
    }

    private void InitParsels()
    {

        foreach (var parsel in _parsels) 
        {
            parsel.init();
        
        }

    }


}
