using GOLAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLAD.Controllers
{
    public class CellController
    {
        private string previousDrawing;
        private static Cell[,] CellGrid; 
        Random CellRandomizer = new Random();
        private Cell LivingCell = new Cell("*", true);
        private Cell DeadCell = new Cell(" ", false);

        public bool GameIsNotOver { set; get; }

        public CellController()
        {
            GameIsNotOver = true;
        }

        /// <summary>
        /// Decide where to put living cells
        /// </summary>
        /// <param name="grid"></param>
        public void GenerateCells(int height, int width)
        {
            CellGrid = new Cell[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    CellGrid[i, j] = CellRandomizer.Next(2) == 1 ? LivingCell : DeadCell;
                    CellGrid[i, j].Coordinates = new int[] { i, j };
                }
        }

        /// <summary>
        /// Displays the cells in the console
        /// </summary>
        public void DrawCells()
        {
            var sB = new StringBuilder();
            Console.Clear();
            for (int i = 0; i < CellGrid.GetLength(0); i++)
            {
                for (int j = 0; j < CellGrid.GetLength(1); j++)
                    sB.Append(CellGrid[i, j].Display);
                sB.AppendLine();
            }

            if (previousDrawing == sB.ToString())
                GameIsNotOver = false;
            previousDrawing = sB.ToString();

            Console.WriteLine(sB.ToString());
        }

        /// <summary>
        /// Updates the generation
        /// </summary>
        public void UpdateGrid()
        {
            Cell[,] newGrid = new Cell[CellGrid.GetLength(0), CellGrid.GetLength(1)];
            for (int i = 0; i < CellGrid.GetLength(0); i++)
                for (int j = 0; j < CellGrid.GetLength(1); j++)
                {
                    int neighbourCount = GetNeighbourCount(CellGrid[i, j]);

                    if (CellGrid[i, j].IsAlive && (neighbourCount < 2 || neighbourCount > 3))
                        newGrid[i, j] = DeadCell;

                    else if (!CellGrid[i, j].IsAlive && neighbourCount == 3)
                        newGrid[i, j] = LivingCell;

                    else
                        newGrid[i, j] = CellGrid[i, j];

                    newGrid[i, j].Coordinates = new int[] { i, j };
                }
            CellGrid = newGrid;
        }

        /// <summary>
        /// Gets the number of neighbours around a cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private int GetNeighbourCount(Cell cell)
        {
            int neighbourCount = 0;
            for (int i = cell.Coordinates[0] - 1; i <= cell.Coordinates[0] + 1; i++)
                for (int j = cell.Coordinates[1] - 1; j <= cell.Coordinates[1] + 1; j++)
                {
                    if (i < 0 || j < 0 || i > CellGrid.GetLength(0) - 1 || j > CellGrid.GetLength(1) - 1)
                        continue;

                    if(CellGrid[i,j]!=cell && CellGrid[i, j].IsAlive)
                            neighbourCount++;
                }
            return neighbourCount;
        }
    }
}
