using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeDependencies.Model;

namespace GameOfLifeRuleEngine.Interface
{
    interface IGameOfLife
    {
        IEnumerable<GridIndex> Initialize();
        IEnumerable<GridIndex> Evolve(int count, IEnumerable<GridIndex> fullGridIndex);
    }
}
