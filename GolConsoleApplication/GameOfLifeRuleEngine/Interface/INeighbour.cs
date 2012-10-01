using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeDependencies.Model;
namespace GameOfLifeRuleEngine.Interface
{
    public interface INeighbour
    {
        IEnumerable<IGridIndex> ValidateNeighbours(int row, int col, List<GridIndex> gridIndex);
    }
}
