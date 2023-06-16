using UnityEngine;
using UnityEngine.Serialization;
using WasderGQ.Sudoku.AIs;
using WasderGQ.Sudoku.Enums;
using WasderGQ.Utility.UnityEditor;

namespace WasderGQ.Sudoku.Scenes.GameScene.Game.Boards
{
    public class Boardx9 : Board
{
    [SerializeField] public readonly GameBoards GameBoards = GameBoards.x9;
    
    public override void InIt()
    {
        ConvertParselZonesToZones();
        base.ParselsInIt();
        base.SetZonesID();
        base.AddMapCreater();
        base.StartMapCreater();
        
    }

    protected override void ConvertParselZonesToZones()
    {
        try
        {
            _zones = new Zone[9,9]
            
            {{ _parselsList[0].ZonesInParsel[0], _parselsList[0].ZonesInParsel[1], _parselsList[0].ZonesInParsel[2], /***/ _parselsList[1].ZonesInParsel[0], _parselsList[1].ZonesInParsel[1], _parselsList[1].ZonesInParsel[2], /***/ _parselsList[2].ZonesInParsel[0], _parselsList[2].ZonesInParsel[1], _parselsList[2].ZonesInParsel[2] },
          { _parselsList[0].ZonesInParsel[3], _parselsList[0].ZonesInParsel[4], _parselsList[0].ZonesInParsel[5], /***/ _parselsList[1].ZonesInParsel[3], _parselsList[1].ZonesInParsel[4], _parselsList[1].ZonesInParsel[5], /***/ _parselsList[2].ZonesInParsel[3], _parselsList[2].ZonesInParsel[4], _parselsList[2].ZonesInParsel[5] },
          { _parselsList[0].ZonesInParsel[6], _parselsList[0].ZonesInParsel[7], _parselsList[0].ZonesInParsel[8], /***/ _parselsList[1].ZonesInParsel[6], _parselsList[1].ZonesInParsel[7], _parselsList[1].ZonesInParsel[8], /***/ _parselsList[2].ZonesInParsel[6], _parselsList[2].ZonesInParsel[7], _parselsList[2].ZonesInParsel[8] },
         //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parselsList[3].ZonesInParsel[0], _parselsList[3].ZonesInParsel[1], _parselsList[3].ZonesInParsel[2], /***/ _parselsList[4].ZonesInParsel[0], _parselsList[4].ZonesInParsel[1], _parselsList[4].ZonesInParsel[2], /***/ _parselsList[5].ZonesInParsel[0], _parselsList[5].ZonesInParsel[1], _parselsList[5].ZonesInParsel[2] },
          { _parselsList[3].ZonesInParsel[3], _parselsList[3].ZonesInParsel[4], _parselsList[3].ZonesInParsel[5], /***/ _parselsList[4].ZonesInParsel[3], _parselsList[4].ZonesInParsel[4], _parselsList[4].ZonesInParsel[5], /***/ _parselsList[5].ZonesInParsel[3], _parselsList[5].ZonesInParsel[4], _parselsList[5].ZonesInParsel[5] },
          { _parselsList[3].ZonesInParsel[6], _parselsList[3].ZonesInParsel[7], _parselsList[3].ZonesInParsel[8], /***/ _parselsList[4].ZonesInParsel[6], _parselsList[4].ZonesInParsel[7], _parselsList[4].ZonesInParsel[8], /***/ _parselsList[5].ZonesInParsel[6], _parselsList[5].ZonesInParsel[7], _parselsList[5].ZonesInParsel[8] },
         /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          { _parselsList[6].ZonesInParsel[0], _parselsList[6].ZonesInParsel[1], _parselsList[6].ZonesInParsel[2], /***/ _parselsList[7].ZonesInParsel[0], _parselsList[7].ZonesInParsel[1], _parselsList[7].ZonesInParsel[2], /***/ _parselsList[8].ZonesInParsel[0], _parselsList[8].ZonesInParsel[1], _parselsList[8].ZonesInParsel[2] },
          { _parselsList[6].ZonesInParsel[3], _parselsList[6].ZonesInParsel[4], _parselsList[6].ZonesInParsel[5], /***/ _parselsList[7].ZonesInParsel[3], _parselsList[7].ZonesInParsel[4], _parselsList[7].ZonesInParsel[5], /***/ _parselsList[8].ZonesInParsel[3], _parselsList[8].ZonesInParsel[4], _parselsList[8].ZonesInParsel[5] },
          { _parselsList[6].ZonesInParsel[6], _parselsList[6].ZonesInParsel[7], _parselsList[6].ZonesInParsel[8], /***/ _parselsList[7].ZonesInParsel[6], _parselsList[7].ZonesInParsel[7], _parselsList[7].ZonesInParsel[8], /***/ _parselsList[8].ZonesInParsel[6], _parselsList[8].ZonesInParsel[7], _parselsList[8].ZonesInParsel[8] },
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

