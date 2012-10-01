using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeDependencies;
using GameOfLifeDependencies.Model;
using GameOfLifeDependencies.Helpers;
using GameOfLifeRuleEngine.Interface;
namespace GameOfLifeRuleEngine
{
    public class Neighbour: INeighbour
    {

        /// <summary>
        /// Checks if there exists a neighbour cell which is alive - checks in surrounding 8 cells
        /// This is done to validate if the present cell should live or die or should spawn as a new cell
        /// 1.Top Left Neighbour
        /// 2.Top Right Neighbour
        /// 3.Top Neighbour
        /// 4.Left Neighbour
        /// 5.Right Neighbour
        /// 6.Bottom Right Negihbour
        /// 7.Bottom Left Neighbour
        /// 8.Bottom Neighbour
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="gridIndex"></param>
        /// <returns>IEnumerable of GridIndex</returns>
        public IEnumerable<IGridIndex> ValidateNeighbours(int row, int col, List<GridIndex> gridIndex)
        {
            var neighbourGrids = new List<IGridIndex>();
            IGridIndex neighbourGrid = new GridIndex();
            
            //Top Left Neighbour
            neighbourGrid = CalculateNeighbour(row - 1, col - 1,gridIndex);
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            neighbourGrid = null;

            //Top Right Neighbour
            neighbourGrid = CalculateNeighbour(row - 1, col + 1, gridIndex);//TopRight
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            neighbourGrid = null;


            //Bootom Left Neighbour
            neighbourGrid = CalculateNeighbour(row + 1, col - 1, gridIndex);//BottomLeft
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            neighbourGrid = null;

            //Bottom Right Neighbour
            neighbourGrid = CalculateNeighbour(row + 1, col + 1, gridIndex);//BottomRight
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            
            //Top Neighbour
            neighbourGrid = CalculateNeighbour(row - 1, col, gridIndex);//Top
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            neighbourGrid = null;

            //Bottom Neighbour
            neighbourGrid = CalculateNeighbour(row + 1, col, gridIndex);//Bottom
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            neighbourGrid = null;

            //Left Neighbour
            neighbourGrid = CalculateNeighbour(row, col - 1, gridIndex);//Left
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            neighbourGrid = null;

            //Right Neighbour
            neighbourGrid = CalculateNeighbour(row, col + 1, gridIndex);//Right
            if (neighbourGrid != null && neighbourGrid.isAlive)
            {
                neighbourGrids.Add(neighbourGrid);
            }
            neighbourGrid = null;

            return neighbourGrids;
        }

        /// <summary>
        /// Calculates the Neighbour and validates if the neighbour is alive
        /// </summary>
        /// <param name="neighbourRowIndex"></param>
        /// <param name="neighbourColIndex"></param>
        /// <param name="gridIndex"></param>
        /// <returns></returns>
        private GridIndex CalculateNeighbour(int neighbourRowIndex, int neighbourColIndex, List<GridIndex> gridIndex)
        {
            var helper = new Helper();
            if (IsNeighbourIndexValid(neighbourRowIndex, neighbourColIndex))
            {
                bool isNeighbourAlive =helper.ValidateLivingCell(neighbourRowIndex, neighbourColIndex, gridIndex);
                if (isNeighbourAlive)
                {
                    return new GridIndex { RowIndex = neighbourRowIndex, ColIndex = neighbourColIndex, isAlive = true };
                }
                else
                {
                    return new GridIndex { RowIndex = neighbourRowIndex, ColIndex = neighbourColIndex, isAlive = false };
                }
            }

            return null;
        }
        /// <summary>
        /// upperbound calcuation of the cell
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private bool IsNeighbourIndexValid(int rowIndex, int colIndex)
        {
            int rowUpperLimit = Grid.NumberOfRows - 1;
            int colUpperLimit = Grid.NumberOfCols - 1;

            if (rowIndex > rowUpperLimit || rowIndex < 0)
            {
                return false;
            }

            if (colIndex > colUpperLimit || colIndex < 0)
            {
                return false;
            }

            return true;
        }

    }
}
