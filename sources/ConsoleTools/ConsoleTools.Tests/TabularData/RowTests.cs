﻿// ConsoleTools
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

using DustInTheWind.ConsoleTools.TabularData;
using NUnit.Framework;

namespace DustInTheWind.ConsoleTools.Tests.TabularData
{
    [TestFixture]
    public class RowTests
    {
        [Test]
        public void Constructor_sets_ParentRow_for_each_cell()
        {
            DataCell cell0 = new DataCell("cell content");
            DataCell cell1 = new DataCell("cell content");
            DataCell cell2 = new DataCell("cell content");

            DataRow row = new DataRow(cell0, cell1, cell2);

            Assert.That(cell0.ParentRow, Is.SameAs(row));
            Assert.That(cell1.ParentRow, Is.SameAs(row));
            Assert.That(cell2.ParentRow, Is.SameAs(row));
        }

        [Test]
        public void Constructor_keeps_the_received_Cell_instances()
        {
            DataCell cell0 = new DataCell("cell content");
            DataCell cell1 = new DataCell("cell content");
            DataCell cell2 = new DataCell("cell content");

            DataRow row = new DataRow(cell0, cell1, cell2);

            Assert.That(row[0], Is.SameAs(cell0));
            Assert.That(row[1], Is.SameAs(cell1));
            Assert.That(row[2], Is.SameAs(cell2));
        }

        [Test]
        public void Constructor_created_empty_Cell_if_one_item_is_null()
        {
            DataCell cell0 = new DataCell("cell content");
            DataCell cell2 = new DataCell("cell content");

            DataRow row = new DataRow(cell0, null, cell2);

            Assert.That(row[1], Is.InstanceOf<DataCell>());
            Assert.That(row[1].IsEmpty, Is.True);
        }
    }
}