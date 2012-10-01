using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeDependencies.Model;
namespace GameOfLifeDependencies.Helpers
{
    public class Helper
    {
        public bool ValidateLivingCell(int neighbourRowIndex, int neighbourColIndex, List<GridIndex> gridIndex)
        {
            try
            {
                int indexCount = gridIndex.FindIndex((s => s.RowIndex == neighbourRowIndex && s.ColIndex == neighbourColIndex && s.isAlive == true));
                //if (gridIndex.Contains(new GridIndex { ColIndex = neighbourColIndex, RowIndex = neighbourRowIndex, isAlive = true }))//(s => s.RowIndex == neighbourRowIndex && s.ColIndex == neighbourColIndex && s.isAlive == true);
                if (indexCount > -1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int[] ValidateCell(string rowColumn)
        {
            if (!rowColumn.Contains(','))//no valid row,col index pair
            {
                throw new ArgumentException(string.Format("The row column pair {0} has no rowColumn separator", rowColumn));
            }

            var cellIndex = rowColumn.Split(',');
            if (!cellIndex.Any())//no valid row,col index
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumn));
            }

            int rowIndex;
            if (!Int32.TryParse(cellIndex[0], out rowIndex) || rowIndex < 0 || rowIndex >= Grid.NumberOfRows)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumn));
            }

            int colIndex;
            if (!Int32.TryParse(cellIndex[1], out colIndex) || colIndex < 0 || colIndex >= Grid.NumberOfCols)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumn));
            }

            return new[] { rowIndex, colIndex };
        }
    }
}
