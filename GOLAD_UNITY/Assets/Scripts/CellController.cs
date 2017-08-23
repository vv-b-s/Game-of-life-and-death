using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CellController : MonoBehaviour
{
    public int GridHeight, GridWidth;
    private static GameObject[,] CellGrid;
    public GameObject LivingCell;
    public GameObject DeadCell;

    public Transform BoardHolder;

    /// <summary>
    /// Decide where to put living cells
    /// </summary>
    /// <param name="grid"></param>
    public void GenerateCells()
    {
        CellGrid = new GameObject[GridHeight, GridWidth];
        for (int i = 0; i < GridHeight; i++)
            for (int j = 0; j < GridWidth; j++)
                CellGrid[i, j] = Random.Range(0,2) == 1 ? LivingCell : DeadCell;
            
    }

    /// <summary>
    /// Displays the cells in the game
    /// </summary>
    public void DrawCells()
    {
        GameObject Board = GameObject.Find("Board");
        if (Board != null)
            Destroy(Board);
        BoardHolder = new GameObject("Board").transform;

        for (int i = 0; i < CellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < CellGrid.GetLength(1); j++)
            {
                var instance = Instantiate(CellGrid[i, j], new Vector2(i, j), Quaternion.identity) as GameObject;
                instance.transform.SetParent(BoardHolder);
            }
        }
    }

    /// <summary>
    /// Updates the generation
    /// </summary>
    public void UpdateGrid()
    {
        GameObject[,] newGrid = new GameObject[CellGrid.GetLength(0), CellGrid.GetLength(1)];
        for (int i = 0; i < CellGrid.GetLength(0); i++)
            for (int j = 0; j < CellGrid.GetLength(1); j++)
            {
                int neighbourCount = GetNeighbourCount(CellGrid[i, j],new int[] { i, j });

                if (CellGrid[i, j].tag=="LivingCell" && (neighbourCount < 2 || neighbourCount > 3))
                    newGrid[i, j] = DeadCell;

                else if (CellGrid[i, j].tag=="DeadCell" && neighbourCount == 3)
                    newGrid[i, j] = LivingCell;

                else
                    newGrid[i, j] = CellGrid[i, j];
            }
        CellGrid = newGrid;
    }

    /// <summary>
    /// Gets the number of neighbours around a cell
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    private int GetNeighbourCount(GameObject cell, int[] gridCoordinates)
    {
        int neighbourCount = 0;
        for (int i = gridCoordinates[0] - 1; i <= gridCoordinates[0] + 1; i++)
            for (int j = gridCoordinates[1] - 1; j <= gridCoordinates[1] + 1; j++)
            {
                if (i < 0 || j < 0 || i > CellGrid.GetLength(0) - 1 || j > CellGrid.GetLength(1) - 1)
                    continue;

                if (!(i==gridCoordinates[0]&&j==gridCoordinates[1]) && CellGrid[i, j].tag == "LivingCell") 
                    neighbourCount++;
            }
        return neighbourCount;
    }
}	