using UnityEngine;
using WasderGQ.Sudoku.AIs;

namespace WasderGQ.Sudoku.Scenes.GameScene.Game
{
    public class Board : MonoBehaviour
{

    [SerializeField] private Parsel[] _parselList;
    [SerializeField] private Zone[,] _allZones;
    [SerializeField] private MapCreater _botMap;
    
    
    public Parsel[] Parsel { get => _parselList; }
    public Zone[,] AllZones { get => _allZones; }
    
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
            _allZones = new Zone[9,9]
            
            {{ _parselList[0].ZonesInParsel[0], _parselList[0].ZonesInParsel[1], _parselList[0].ZonesInParsel[2], /***/ _parselList[1].ZonesInParsel[0], _parselList[1].ZonesInParsel[1], _parselList[1].ZonesInParsel[2], /***/ _parselList[2].ZonesInParsel[0], _parselList[2].ZonesInParsel[1], _parselList[2].ZonesInParsel[2] },
          { _parselList[0].ZonesInParsel[3], _parselList[0].ZonesInParsel[4], _parselList[0].ZonesInParsel[5], /***/ _parselList[1].ZonesInParsel[3], _parselList[1].ZonesInParsel[4], _parselList[1].ZonesInParsel[5], /***/ _parselList[2].ZonesInParsel[3], _parselList[2].ZonesInParsel[4], _parselList[2].ZonesInParsel[5] },
          { _parselList[0].ZonesInParsel[6], _parselList[0].ZonesInParsel[7], _parselList[0].ZonesInParsel[8], /***/ _parselList[1].ZonesInParsel[6], _parselList[1].ZonesInParsel[7], _parselList[1].ZonesInParsel[8], /***/ _parselList[2].ZonesInParsel[6], _parselList[2].ZonesInParsel[7], _parselList[2].ZonesInParsel[8] },
         //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parselList[3].ZonesInParsel[0], _parselList[3].ZonesInParsel[1], _parselList[3].ZonesInParsel[2], /***/ _parselList[4].ZonesInParsel[0], _parselList[4].ZonesInParsel[1], _parselList[4].ZonesInParsel[2], /***/ _parselList[5].ZonesInParsel[0], _parselList[5].ZonesInParsel[1], _parselList[5].ZonesInParsel[2] },
          { _parselList[3].ZonesInParsel[3], _parselList[3].ZonesInParsel[4], _parselList[3].ZonesInParsel[5], /***/ _parselList[4].ZonesInParsel[3], _parselList[4].ZonesInParsel[4], _parselList[4].ZonesInParsel[5], /***/ _parselList[5].ZonesInParsel[3], _parselList[5].ZonesInParsel[4], _parselList[5].ZonesInParsel[5] },
          { _parselList[3].ZonesInParsel[6], _parselList[3].ZonesInParsel[7], _parselList[3].ZonesInParsel[8], /***/ _parselList[4].ZonesInParsel[6], _parselList[4].ZonesInParsel[7], _parselList[4].ZonesInParsel[8], /***/ _parselList[5].ZonesInParsel[6], _parselList[5].ZonesInParsel[7], _parselList[5].ZonesInParsel[8] },
         /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parselList[6].ZonesInParsel[0], _parselList[6].ZonesInParsel[1], _parselList[6].ZonesInParsel[2], /***/ _parselList[7].ZonesInParsel[0], _parselList[7].ZonesInParsel[1], _parselList[7].ZonesInParsel[2], /***/ _parselList[8].ZonesInParsel[0], _parselList[8].ZonesInParsel[1], _parselList[8].ZonesInParsel[2] },
          { _parselList[6].ZonesInParsel[3], _parselList[6].ZonesInParsel[4], _parselList[6].ZonesInParsel[5], /***/ _parselList[7].ZonesInParsel[3], _parselList[7].ZonesInParsel[4], _parselList[7].ZonesInParsel[5], /***/ _parselList[8].ZonesInParsel[3], _parselList[8].ZonesInParsel[4], _parselList[8].ZonesInParsel[5] },
          { _parselList[6].ZonesInParsel[6], _parselList[6].ZonesInParsel[7], _parselList[6].ZonesInParsel[8], /***/ _parselList[7].ZonesInParsel[6], _parselList[7].ZonesInParsel[7], _parselList[7].ZonesInParsel[8], /***/ _parselList[8].ZonesInParsel[6], _parselList[8].ZonesInParsel[7], _parselList[8].ZonesInParsel[8] },
        };
            Debug.Log("All Zones saved to Board");
        }
        catch
        { 
            Debug.LogError("All zones CAN'T saved to Board");

        }
    }

    /// <Important>
    /// board hangi zone secili oldupunu bilmeli ve keyboarddan bilgiyi alip board�n kendisi bu bilgiyi yazmasi gerekli.
    /// sadece board zone degerlerini vermeli ama kendi uzerine degerli yamaya zoneler yapmali.
    /// <Important End !!!>


    private void AddSudokuBot()
    {
        try 
        {
            _botMap = new MapCreater(_allZones, _parselList);
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
       // bool SudokuSolverStart = await _botMap.SudokuSolverStart();
       // string messege = SudokuSolverStart ? "Sudokubot Done" : "Sudokubot failed to finish!!!!";
       // Debug.LogError(messege);

    }



}
}

