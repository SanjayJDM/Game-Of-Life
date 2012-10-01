using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeDependencies;
using GameOfLifeDependencies.Model;
using GameOfLifeDependencies.Helpers;

namespace GameOfLifeUILibrary
{
    public class GameOfLifeUILib
    {
        private int _numberOfRows;
        private int _numberOfCols;
        private string _liveCells;
        private int _numberOfEvolution;

        public void ShowInputScreen()
        {
            Console.WriteLine("Game Of Life\n\n");
            while (!NumberOfRows())
            {
                Console.WriteLine("Row Input Error");
            }
            while (!NumberOfCols())
            {
                Console.WriteLine("Coloumn Input Error");
            }
            while (!LiveCells())
            {
                Console.WriteLine("Live Cells Input Error");
            }
            while (!NumberOfEvolution())
            {
                Console.WriteLine("Evolution Input Error");
            }
            Console.WriteLine("Press Enter key to continue.");
            Console.ReadLine();
        }


        private bool NumberOfCols()
        {
            int numberOfCols;
            Console.WriteLine("Enter number of cols followed by Enter key.");
            var colInput = Console.ReadLine();
            if (Int32.TryParse(colInput, out numberOfCols))
            {
                Grid.NumberOfCols = numberOfCols;
                return true;
            }
            return false;
        }

        private bool NumberOfRows()
        {
            int numberOfRows;
            Console.WriteLine("Enter number of rows followed by Enter key.");
            var rowInput = Console.ReadLine();
            if (Int32.TryParse(rowInput, out numberOfRows))
            {
                Grid.NumberOfRows = numberOfRows;
                return true;
            }
            return false;
        }

        private bool LiveCells()
        {
            Console.WriteLine("Enter the Live Cells (x,x) seperated by | (Pipe Symbol). E.g 0,1|1,1|2,1");
            var LiveCells = Console.ReadLine();
            try
            {
                LiveCells = LiveCells.Trim(' ', '|');

                Helper helper = new Helper();
                if (LiveCells.Length != 0)//no alive cells
                {
                    var rowColumns = LiveCells.Split('|');
                    foreach (var rowColumn in rowColumns)
                    {
                        int[] index = helper.ValidateCell(rowColumn);
                    }
                }
                Grid.LiveCells = LiveCells;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Quit()
        {
            Console.WriteLine("Carry On? Y/N");
            var userInput = Console.ReadLine();
            if (string.Equals(userInput.Trim(), "Y", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public void PrintEvolution(int evolutionCount)
        {
            Console.WriteLine("Evolution : " + evolutionCount);
        }
        
        private bool NumberOfEvolution()
        {
            int numberOfEvolution;
            Console.WriteLine("Enter number of Evolutions");
            var evolveInput = Console.ReadLine();
            if (Int32.TryParse(evolveInput, out numberOfEvolution))
            {
                Grid.NumberOfEvolution = numberOfEvolution;
                return true;
            }
            return false;
        }

        public void DisplayGrid(IEnumerable<GridIndex> fullGridIndex)
        {
            var builder = new StringBuilder();
            var helper = new Helper();
            for (var rowIndex = 0; rowIndex < Grid.NumberOfRows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Grid.NumberOfCols; columnIndex++)
                {
                    if(helper.ValidateLivingCell(rowIndex,columnIndex, fullGridIndex.ToList<GridIndex>()))
                    {
                        builder.Append("X");
                    }
                    else
                    {
                        builder.Append(".");
                    }
                    builder.Append(' ');
                }
                builder.Append(Environment.NewLine);
            }

            Console.WriteLine(builder.ToString()); ;
        }
    }
}
