using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeDependencies;
using GameOfLifeDependencies.Model;
using GameOfLifeDependencies.Helpers;


namespace GameOfLifeRuleEngine
{
    public class GameOfLife
    {

        public IEnumerable<GridIndex> Initialize()
        {
            
            var gridIndex = CreateGrid();
            gridIndex = ValidateAndAssignAliveCells(gridIndex);
            return gridIndex;
        }

        //Initializer
        private IEnumerable<GridIndex> CreateGrid()
        {
            var grids = new List<GridIndex>();
            for (int rowIndex = 0; rowIndex < Grid.NumberOfRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < Grid.NumberOfCols; colIndex++)
                {
                    grids.Add(new GridIndex { RowIndex = rowIndex, ColIndex = colIndex });
                }
            }
            return grids;
        }

        private IEnumerable<GridIndex> ValidateAndAssignAliveCells(IEnumerable<GridIndex> gridIndex)
        {
            string gridRowColumnString = Grid.LiveCells;
            gridRowColumnString = gridRowColumnString.Trim(' ', '|');

            Helper helper = new Helper();
            if (gridRowColumnString.Length != 0)//no alive cells
            {
                var rowColumns = gridRowColumnString.Split('|');
                foreach (var rowColumn in rowColumns)
                {
                    int[] index = helper.ValidateCell(rowColumn);
                    var grid = gridIndex.Single(s => s.RowIndex == index[0] && s.ColIndex == index[1]);
                    grid.isAlive = true;
                }
            }
            return gridIndex;
        }


        //Evolving
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="fullGridIndex"></param>
        /// <returns></returns>
        /// <Rules>
    ///Any live cell with fewer than two live neighbours dies, as if caused by under-population.
    ///Any live cell with two or three live neighbours lives on to the next generation.
    ///Any live cell with more than three live neighbours dies, as if by overcrowding.
    ///Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        /// </Rules>
        public IEnumerable<GridIndex> Evolve(int count, List<GridIndex> fullGridIndex)
        {
            IEnumerable<IGridIndex> EvolvedGrids = new List<GridIndex>();

            var neighbour = new Neighbour();
            for (int rowIndex = 0; rowIndex < Grid.NumberOfRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < Grid.NumberOfCols; colIndex++)
                {
                    EvolvedGrids = neighbour.ValidateNeighbours(rowIndex, colIndex, fullGridIndex);
                    if (EvolvedGrids.Count<IGridIndex>() == 3)
                    {
                        try
                        {
                            fullGridIndex.Single(s => s.RowIndex == rowIndex && s.ColIndex == colIndex).isAlive = true;
                        }
                        catch (Exception ex)
                        { }
                        //grid.isAlive = true;
                    }
                    else if (EvolvedGrids.Count<IGridIndex>() == 2)
                    {
                        if (fullGridIndex.Single(s => s.RowIndex == rowIndex && s.ColIndex == colIndex).isAlive==true )
                        {
                            fullGridIndex.Single(s => s.RowIndex == rowIndex && s.ColIndex == colIndex).isAlive = true;
                        }
                    }
                    else if ((EvolvedGrids.Count<IGridIndex>() < 2) || (EvolvedGrids.Count<IGridIndex>() > 3))
                    {
                        fullGridIndex.Single(s => s.RowIndex == rowIndex && s.ColIndex == colIndex).isAlive = false;
                    }
                }
            }
            return fullGridIndex;
        }
    }
}
