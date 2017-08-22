using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLAD.Models
{
    struct Cell
    {
        public string Display { set; get; }
        public bool IsAlive { set; get; }

        public int[] Coordinates { set; get; }

        public Cell(string display, bool isAlive)
        {
            Display = display;
            IsAlive = isAlive;
            Coordinates = null;
        }

        public static bool operator == (Cell cell1, Cell cell2) => cell1.Coordinates[0] == cell2.Coordinates[0] && cell1.Coordinates[1] == cell2.Coordinates[1];
        public static bool operator !=(Cell cell1, Cell cell2) => !(cell1.Coordinates[0] == cell2.Coordinates[0] && cell1.Coordinates[1] == cell2.Coordinates[1]);


    }
}
