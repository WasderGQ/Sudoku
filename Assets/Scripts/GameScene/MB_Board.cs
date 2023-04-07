using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MB_Board : MonoBehaviour
{

    [SerializeField] private MB_Parsel[] _parsels;
    [SerializeField] private MB_Zone[,] _allZones;
    [SerializeField] private SudokuCreater _botSudoku;
    [SerializeField] private MB_Keyboard _keyboard;

    public MB_Parsel[] Parsel { get => _parsels; }
    public MB_Zone[,] AllZones { get => _allZones; }

    public void init()
    {
        
        InitParsels();
        KeyboardInIt();
        EventsListener();
        FillMathZones();
        AddSudokuBot(); 
        StartSudokuBot();
        
        

    }


    private void EventsListener()
    {

        ZonesButtonAddListener();
    }



    private void InitParsels()
    {

        foreach (var parsel in _parsels)
        {
            parsel.init();

        }

    }
    private void KeyboardInIt()
    {
        _keyboard.init();


    }
    private void ZonesButtonAddListener() //Sending to keyboard
    {

        foreach (var parsel in _parsels)
        {
            foreach (var zone in parsel.ZonesInParsel)
            {
                zone.GetComponent<Button>().onClick.AddListener(() => _keyboard.SelectedZoneTaker(zone.SelectedZone()));
            }

        }


    }






    private void FillMathZones()
    {
        try
        {
            _allZones = new MB_Zone[,]

        { { _parsels[0].ZonesInParsel[0], _parsels[0].ZonesInParsel[1], _parsels[0].ZonesInParsel[2],/***/ _parsels[1].ZonesInParsel[0], _parsels[1].ZonesInParsel[1], _parsels[1].ZonesInParsel[2],/***/ _parsels[2].ZonesInParsel[0], _parsels[2].ZonesInParsel[1], _parsels[2].ZonesInParsel[2] },
          { _parsels[0].ZonesInParsel[3], _parsels[0].ZonesInParsel[4], _parsels[0].ZonesInParsel[5],/***/ _parsels[1].ZonesInParsel[3], _parsels[1].ZonesInParsel[4], _parsels[1].ZonesInParsel[5],/***/ _parsels[2].ZonesInParsel[3], _parsels[2].ZonesInParsel[4], _parsels[2].ZonesInParsel[5] },
          { _parsels[0].ZonesInParsel[6], _parsels[0].ZonesInParsel[7], _parsels[0].ZonesInParsel[8],/***/ _parsels[1].ZonesInParsel[6], _parsels[1].ZonesInParsel[7], _parsels[1].ZonesInParsel[8],/***/ _parsels[2].ZonesInParsel[6], _parsels[2].ZonesInParsel[7], _parsels[2].ZonesInParsel[8] },
         ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parsels[3].ZonesInParsel[0], _parsels[3].ZonesInParsel[1], _parsels[3].ZonesInParsel[2],/***/ _parsels[4].ZonesInParsel[0], _parsels[4].ZonesInParsel[1], _parsels[4].ZonesInParsel[2],/***/ _parsels[5].ZonesInParsel[0], _parsels[5].ZonesInParsel[1], _parsels[5].ZonesInParsel[2] },
          { _parsels[3].ZonesInParsel[3], _parsels[3].ZonesInParsel[4], _parsels[3].ZonesInParsel[5],/***/ _parsels[4].ZonesInParsel[3], _parsels[4].ZonesInParsel[4], _parsels[4].ZonesInParsel[5],/***/ _parsels[5].ZonesInParsel[3], _parsels[5].ZonesInParsel[4], _parsels[5].ZonesInParsel[5] },
          { _parsels[3].ZonesInParsel[6], _parsels[3].ZonesInParsel[7], _parsels[3].ZonesInParsel[8],/***/ _parsels[4].ZonesInParsel[6], _parsels[4].ZonesInParsel[7], _parsels[4].ZonesInParsel[8],/***/ _parsels[5].ZonesInParsel[6], _parsels[5].ZonesInParsel[7], _parsels[5].ZonesInParsel[8] },
         ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parsels[6].ZonesInParsel[0], _parsels[6].ZonesInParsel[1], _parsels[6].ZonesInParsel[2],/***/ _parsels[7].ZonesInParsel[0], _parsels[7].ZonesInParsel[1], _parsels[7].ZonesInParsel[2],/***/ _parsels[8].ZonesInParsel[0], _parsels[8].ZonesInParsel[1], _parsels[8].ZonesInParsel[2] },
          { _parsels[6].ZonesInParsel[3], _parsels[6].ZonesInParsel[4], _parsels[6].ZonesInParsel[5],/***/ _parsels[7].ZonesInParsel[3], _parsels[7].ZonesInParsel[4], _parsels[7].ZonesInParsel[5],/***/ _parsels[8].ZonesInParsel[3], _parsels[8].ZonesInParsel[4], _parsels[8].ZonesInParsel[5] },
          { _parsels[6].ZonesInParsel[6], _parsels[6].ZonesInParsel[7], _parsels[6].ZonesInParsel[8],/***/ _parsels[7].ZonesInParsel[6], _parsels[7].ZonesInParsel[7], _parsels[7].ZonesInParsel[8],/***/ _parsels[8].ZonesInParsel[6], _parsels[8].ZonesInParsel[7], _parsels[8].ZonesInParsel[8] },
        };
            Debug.Log("All Zones saved to Board");
        }
        catch
        { 
            Debug.Log("All zones CAN'T saved to Board");

        }
    }

    /// <Önemliiii>
    /// board hangi zone secili oldupunu bilmeli ve keyboarddan bilgiyi alýp boardýn kendisi bu bilgiyi yazmasý gerekli.
    /// sadece board zone deðerlerini vermeli ama kendi üzerine deðerli yamayý zoneler yapmalý.
    /// </Öenmli son!!!>


    private void AddSudokuBot()
    {
        try 
        {
            _botSudoku = new SudokuCreater(_allZones, _parsels);
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
