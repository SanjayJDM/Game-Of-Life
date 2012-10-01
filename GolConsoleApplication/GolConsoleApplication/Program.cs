using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeDependencies;
using GameOfLifeDependencies.Model;
using GameOfLifeDependencies.Helpers;

using GameOfLifeRuleEngine;

using GameOfLifeUILibrary;

namespace GolConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var UI = new GameOfLifeUILib();
            var gameOfLife = new GameOfLife();
            IEnumerable<GridIndex> fullGridIndex;
           do
            {
                UI.ShowInputScreen();
                fullGridIndex = gameOfLife.Initialize();
                UI.DisplayGrid(fullGridIndex);

                for (int i = 0; i <= Grid.NumberOfEvolution; i++)
                {
                    fullGridIndex = gameOfLife.Evolve(i, fullGridIndex.ToList<GridIndex>());
                    UI.PrintEvolution(i);
                    UI.DisplayGrid(fullGridIndex);
                }
            }
            while (UI.Quit());
         }
    }
}
