using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeDependencies.Model
{
    public interface IGridIndex
    {
        /// <summary>
        /// gets/sets rows index of a cell
        /// </summary>
        int RowIndex {get;set;}

        /// <summary>
        /// gets/sets column index of a cell
        /// </summary>
        int ColIndex {get;set;}

        /// <summary>
        /// gets/sets if the the cell object is
        /// alive
        /// </summary>
        bool isAlive { get; set; }
    }

    public class GridIndex : IGridIndex
        {
            /// <summary>
            /// gets/sets rows index of a cell
            /// </summary>
            public int RowIndex { get; set; }

            /// <summary>
            /// gets/sets column index of a cell
            /// </summary>
            public int ColIndex { get; set; }

            /// <summary>
            /// gets/sets if the the cell object is
            /// alive
            /// </summary>
            public bool isAlive { get; set; }
        }
    }
