using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MB_Board : MonoBehaviour
{

    [SerializeField] private MB_Parsel[] _parsels;
    [SerializeField] public MB_Zone[,] _zones;
    [SerializeField] private SudokuCreater _botSudoku;
    [SerializeField] private MB_Keyboard _keyboard;
    public void init()
    {
        
        InitParsels();
        KeyboardInIt();
        EventsListener();
        FillMathZones();
        
        Debug.Log("All zones Saved Board");
        // AddSudokuBot();
        Debug.Log("Sudokubot added Board");
        // StartSudokuBot();
        
        

    }


    private void EventsListener()
    {

        ZonesButtonAddListener();
    }


     




    private void FillMathZones()
    {
        _zones = new MB_Zone[,] 
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

    /// <Önemliiii>
    /// board hangi zone secili oldupunu bilmeli ve keyboarddan bilgiyi alýp boardýn kendisi bu bilgiyi yazmasý gerekli.
    /// sadece board zone deðerlerini vermeli ama kendi üzerine deðerli yamayý zoneler yapmalý.
    /// </Öenmli son!!!>


   private void  KeyboardInIt()
    {
        _keyboard.init();


    }



    private void ZonesButtonAddListener()
    {

        foreach (var parsel in _parsels)
        {
            foreach (var zone in parsel._zones)
            {
                zone.GetComponent<Button>().onClick.AddListener(() => _keyboard.SelectedZoneTaker(zone.SelectedZone()));
            }
            
        }


    }



    private void AddSudokuBot()
    {
        _botSudoku = new SudokuCreater(_zones,_parsels);

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
