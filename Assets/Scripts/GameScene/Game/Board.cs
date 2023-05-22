using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    [FormerlySerializedAs("_parsels")] [SerializeField] private MB_Parsel[] _parselList;
    [SerializeField] private MB_Zone[,] _allZones;
    [SerializeField] private SudokuCreater _botSudoku;
    
    
    public MB_Parsel[] Parsel { get => _parselList; }
    public MB_Zone[,] AllZones { get => _allZones; }
    
    public void init()
    {
        
        InitParsels();
        
        EventsListener();
        AddSudokuBot(); 
        StartSudokuBot();
        
        

    }


    private void EventsListener()
    {

       
    }



    private void InitParsels()
    {

        foreach (var parsel in _parselList)
        {
            parsel.init();

        }

    }
    
    

    

    private void FillZonesToList()
    {
        try
        {
            _allZones = new MB_Zone[9,9]
            
          { { _parselList[0].ZonesInParsel[0], _parselList[0].ZonesInParsel[1], _parselList[0].ZonesInParsel[2],/***/ _parselList[1].ZonesInParsel[0], _parselList[1].ZonesInParsel[1], _parselList[1].ZonesInParsel[2],/***/ _parselList[2].ZonesInParsel[0], _parselList[2].ZonesInParsel[1], _parselList[2].ZonesInParsel[2] },
          { _parselList[0].ZonesInParsel[3], _parselList[0].ZonesInParsel[4], _parselList[0].ZonesInParsel[5],/***/ _parselList[1].ZonesInParsel[3], _parselList[1].ZonesInParsel[4], _parselList[1].ZonesInParsel[5],/***/ _parselList[2].ZonesInParsel[3], _parselList[2].ZonesInParsel[4], _parselList[2].ZonesInParsel[5] },
          { _parselList[0].ZonesInParsel[6], _parselList[0].ZonesInParsel[7], _parselList[0].ZonesInParsel[8],/***/ _parselList[1].ZonesInParsel[6], _parselList[1].ZonesInParsel[7], _parselList[1].ZonesInParsel[8],/***/ _parselList[2].ZonesInParsel[6], _parselList[2].ZonesInParsel[7], _parselList[2].ZonesInParsel[8] },
         ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parselList[3].ZonesInParsel[0], _parselList[3].ZonesInParsel[1], _parselList[3].ZonesInParsel[2],/***/ _parselList[4].ZonesInParsel[0], _parselList[4].ZonesInParsel[1], _parselList[4].ZonesInParsel[2],/***/ _parselList[5].ZonesInParsel[0], _parselList[5].ZonesInParsel[1], _parselList[5].ZonesInParsel[2] },
          { _parselList[3].ZonesInParsel[3], _parselList[3].ZonesInParsel[4], _parselList[3].ZonesInParsel[5],/***/ _parselList[4].ZonesInParsel[3], _parselList[4].ZonesInParsel[4], _parselList[4].ZonesInParsel[5],/***/ _parselList[5].ZonesInParsel[3], _parselList[5].ZonesInParsel[4], _parselList[5].ZonesInParsel[5] },
          { _parselList[3].ZonesInParsel[6], _parselList[3].ZonesInParsel[7], _parselList[3].ZonesInParsel[8],/***/ _parselList[4].ZonesInParsel[6], _parselList[4].ZonesInParsel[7], _parselList[4].ZonesInParsel[8],/***/ _parselList[5].ZonesInParsel[6], _parselList[5].ZonesInParsel[7], _parselList[5].ZonesInParsel[8] },
         ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parselList[6].ZonesInParsel[0], _parselList[6].ZonesInParsel[1], _parselList[6].ZonesInParsel[2],/***/ _parselList[7].ZonesInParsel[0], _parselList[7].ZonesInParsel[1], _parselList[7].ZonesInParsel[2],/***/ _parselList[8].ZonesInParsel[0], _parselList[8].ZonesInParsel[1], _parselList[8].ZonesInParsel[2] },
          { _parselList[6].ZonesInParsel[3], _parselList[6].ZonesInParsel[4], _parselList[6].ZonesInParsel[5],/***/ _parselList[7].ZonesInParsel[3], _parselList[7].ZonesInParsel[4], _parselList[7].ZonesInParsel[5],/***/ _parselList[8].ZonesInParsel[3], _parselList[8].ZonesInParsel[4], _parselList[8].ZonesInParsel[5] },
          { _parselList[6].ZonesInParsel[6], _parselList[6].ZonesInParsel[7], _parselList[6].ZonesInParsel[8],/***/ _parselList[7].ZonesInParsel[6], _parselList[7].ZonesInParsel[7], _parselList[7].ZonesInParsel[8],/***/ _parselList[8].ZonesInParsel[6], _parselList[8].ZonesInParsel[7], _parselList[8].ZonesInParsel[8] },
        };
            Debug.Log("All Zones saved to Board");
        }
        catch
        { 
            Debug.LogError("All zones CAN'T saved to Board");

        }
    }

    /// <Important>
    /// board hangi zone secili oldupunu bilmeli ve keyboarddan bilgiyi al�p board�n kendisi bu bilgiyi yazmas� gerekli.
    /// sadece board zone de�erlerini vermeli ama kendi �zerine de�erli yamay� zoneler yapmal�.
    /// </�enmli son!!!>


    private void AddSudokuBot()
    {
        try 
        {
            _botSudoku = new SudokuCreater(_allZones, _parselList);
            Debug.Log("Sudokubot successfully added to Board ");
        }
        
        catch
        {
            Debug.Log("Sudokubot not added Board !!!!");
        }
    }




    public async void StartSudokuBot()
    {
        Debug.Log("Sudokubot Started Board");
        bool SudokuSolverStart = await _botSudoku.SudokuSolverStart();
        string messege = SudokuSolverStart ? "Sudokubot Done" : "Sudokubot failed to finish!!!!";
        Debug.LogError(messege);

    }



}
