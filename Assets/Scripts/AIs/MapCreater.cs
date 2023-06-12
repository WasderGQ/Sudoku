using System.Collections.Generic;
using WasderGQ.GameScene.Game;

namespace WasderGQ.Sudoku.AIs
{
    public class MapCreater
    {
        private Zone[,] _processedZones;
        private Parsel[] _processedParsels;
        private List<int> _firstFillParsels;


        public MapCreater(Zone[,] zones, Parsel[] parsels)
        {

            _processedZones = zones;
            _processedParsels = parsels;



        }

        ///  ----<Region How to Work>----
        /// Metod parsel pasel init()
        /// first section 0,4,8
        /// second section 2,6
        ///  third section 1,5
        /// Fourth section 3,7
        /// Finally Done
        ///     ----<EndRegion>---
        

    }
}




