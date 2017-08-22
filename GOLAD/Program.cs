using GOLAD.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLAD
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = DateTime.Now;
            var life = new CellController();
            life.GenerateCells(100,100);
            life.DrawCells();
            while (life.GameIsNotOver)
            {
                var newTime = DateTime.Now;
                if(newTime.Second*1000!=time.Second*1000)
                {
                    time = newTime;
                    life.UpdateGrid();
                    life.DrawCells();
                }
            }

            Console.WriteLine("Game is over. No conditions for the cells to reproduce.");
        }
    }
}
