// ConsoleTools
// Copyright (C) 2017-2018 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

// --------------------------------------------------------------------------------
// Bugs or feature requests
// --------------------------------------------------------------------------------
// Note: For any bug or feature request please add a new issue on GitHub: https://github.com/lastunicorn/ConsoleTools/issues/new

using System;
using System.Collections.Generic;

namespace DustInTheWind.ConsoleTools.TabularData.RenderingModel
{
    internal class DataRowX
    {
        private readonly bool hasBorder;
        private readonly DataRow dataRow;
        private readonly List<DataCellX> cells = new List<DataCellX>();

        public Size Size { get; private set; }

        public DataRowX(DataRow dataRow, bool hasBorder)
        {
            if (dataRow == null) throw new ArgumentNullException(nameof(dataRow));

            this.dataRow = dataRow;
            this.hasBorder = hasBorder;

            CreateCells();
        }

        private void CreateCells()
        {
            cells.Clear();

            for (int i = 0; i < dataRow.CellCount; i++)
            {
                DataCellX cell = new DataCellX
                {
                    Size = dataRow[i].CalculatePreferedSize()
                };

                AddCellToSize(cell);

                cells.Add(cell);
            }
        }

        private void AddCellToSize(DataCellX cell)
        {
            int initialCount = cells.Count;

            int width = initialCount == 0 && hasBorder
                ? 1
                : Size.Width;

            width += cell.Size.Width;

            if (hasBorder)
                width++;

            int height = Size.Height < cell.Size.Height
                ? cell.Size.Height
                : Size.Height;

            Size = new Size(width, height);
        }

        public void Render(ITablePrinter tablePrinter, List<int> cellWidths)
        {
            dataRow.Render(tablePrinter, cellWidths, Size.Height);
        }

        public void UpdateColumnsWidths(List<int> columnsWidths)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                while (columnsWidths.Count <= i)
                    columnsWidths.Add(0);

                Size cellSize = cells[i].Size;

                if (cellSize.Width > columnsWidths[i])
                    columnsWidths[i] = cellSize.Width;
            }
        }
    }
}