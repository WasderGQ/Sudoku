using UnityEngine;
using WasderGQ.Sudoku.AIs;
using WasderGQ.Sudoku.Enums;

namespace WasderGQ.Sudoku.Scenes.GameScene.Game.Boards
{
    public class Boardx9 : Board
{
    [SerializeField] public readonly GameBoards GameBoards = GameBoards.x9;
    [SerializeField] private Parsel[] parselsList;
    [SerializeField] private Zone[,] _zones;
    [SerializeField] private MapCreater _mapCreater;
    
    
    public Parsel[] Parsels { get => parselsList; }
    public Zone[,] Zones { get => _zones; }
    
    public override void InIt()
    {
        ConvertParselZonesToZones();
        ParselsInIt();
        base.AddMapCreater(); 
        base.StartMapCreater();
    }

    
    protected override void ParselsInIt()
    {
        foreach (var parsel in parselsList)
        {
            parsel.init();

        }
    }
    
    protected override void ConvertParselZonesToZones()
    {
        try
        {
            _zones = new Zone[9,9]
            
            {{ parselsList[0].ZonesInParsel[0], parselsList[0].ZonesInParsel[1], parselsList[0].ZonesInParsel[2], /***/ parselsList[1].ZonesInParsel[0], parselsList[1].ZonesInParsel[1], parselsList[1].ZonesInParsel[2], /***/ parselsList[2].ZonesInParsel[0], parselsList[2].ZonesInParsel[1], parselsList[2].ZonesInParsel[2] },
          { parselsList[0].ZonesInParsel[3], parselsList[0].ZonesInParsel[4], parselsList[0].ZonesInParsel[5], /***/ parselsList[1].ZonesInParsel[3], parselsList[1].ZonesInParsel[4], parselsList[1].ZonesInParsel[5], /***/ parselsList[2].ZonesInParsel[3], parselsList[2].ZonesInParsel[4], parselsList[2].ZonesInParsel[5] },
          { parselsList[0].ZonesInParsel[6], parselsList[0].ZonesInParsel[7], parselsList[0].ZonesInParsel[8], /***/ parselsList[1].ZonesInParsel[6], parselsList[1].ZonesInParsel[7], parselsList[1].ZonesInParsel[8], /***/ parselsList[2].ZonesInParsel[6], parselsList[2].ZonesInParsel[7], parselsList[2].ZonesInParsel[8] },
         //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { parselsList[3].ZonesInParsel[0], parselsList[3].ZonesInParsel[1], parselsList[3].ZonesInParsel[2], /***/ parselsList[4].ZonesInParsel[0], parselsList[4].ZonesInParsel[1], parselsList[4].ZonesInParsel[2], /***/ parselsList[5].ZonesInParsel[0], parselsList[5].ZonesInParsel[1], parselsList[5].ZonesInParsel[2] },
          { parselsList[3].ZonesInParsel[3], parselsList[3].ZonesInParsel[4], parselsList[3].ZonesInParsel[5], /***/ parselsList[4].ZonesInParsel[3], parselsList[4].ZonesInParsel[4], parselsList[4].ZonesInParsel[5], /***/ parselsList[5].ZonesInParsel[3], parselsList[5].ZonesInParsel[4], parselsList[5].ZonesInParsel[5] },
          { parselsList[3].ZonesInParsel[6], parselsList[3].ZonesInParsel[7], parselsList[3].ZonesInParsel[8], /***/ parselsList[4].ZonesInParsel[6], parselsList[4].ZonesInParsel[7], parselsList[4].ZonesInParsel[8], /***/ parselsList[5].ZonesInParsel[6], parselsList[5].ZonesInParsel[7], parselsList[5].ZonesInParsel[8] },
         /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { parselsList[6].ZonesInParsel[0], parselsList[6].ZonesInParsel[1], parselsList[6].ZonesInParsel[2], /***/ parselsList[7].ZonesInParsel[0], parselsList[7].ZonesInParsel[1], parselsList[7].ZonesInParsel[2], /***/ parselsList[8].ZonesInParsel[0], parselsList[8].ZonesInParsel[1], parselsList[8].ZonesInParsel[2] },
          { parselsList[6].ZonesInParsel[3], parselsList[6].ZonesInParsel[4], parselsList[6].ZonesInParsel[5], /***/ parselsList[7].ZonesInParsel[3], parselsList[7].ZonesInParsel[4], parselsList[7].ZonesInParsel[5], /***/ parselsList[8].ZonesInParsel[3], parselsList[8].ZonesInParsel[4], parselsList[8].ZonesInParsel[5] },
          { parselsList[6].ZonesInParsel[6], parselsList[6].ZonesInParsel[7], parselsList[6].ZonesInParsel[8], /***/ parselsList[7].ZonesInParsel[6], parselsList[7].ZonesInParsel[7], parselsList[7].ZonesInParsel[8], /***/ parselsList[8].ZonesInParsel[6], parselsList[8].ZonesInParsel[7], parselsList[8].ZonesInParsel[8] },
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


   
    

    



}
}

