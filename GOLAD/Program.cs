﻿using GOLAD.Controllers;
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

            Console.Write("Enter height: ");
            int.TryParse(Console.ReadLine(), out int height);

            Console.Write("Enter width: ");
            int.TryParse(Console.ReadLine(), out int width);

            Console.Write("Enter the shape of your living cells (dead cells will be just empty spaces): ");
            string shape = Console.ReadLine();

            Console.Clear();

            var life = new CellController(shape);

            life.GenerateCells(height,width);

            life.DrawCells();
            while (life.GameIsNotOver)
            {
                var newTime = DateTime.Now;
                if(newTime.Second!=time.Second)
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
