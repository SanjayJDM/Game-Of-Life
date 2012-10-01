using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeDependencies.Model
{
    public static class Grid
    {
        /// <summary>
        /// gets/sets the number of rows in the grid
        /// </summary>
        public static int NumberOfRows { get; set; }

        /// <summary>
        /// gets/sets the number of cols in the grid
        /// </summary>
        public static int NumberOfCols { get; set; }

        /// <summary>
        /// gets/sets the number of live cels input from user
        /// </summary>
        public static string LiveCells {get;set;}

        /// <summary>
        /// gets/sets the number of evolution
        /// </summary>
        public static int NumberOfEvolution { get; set; }
    }
}
