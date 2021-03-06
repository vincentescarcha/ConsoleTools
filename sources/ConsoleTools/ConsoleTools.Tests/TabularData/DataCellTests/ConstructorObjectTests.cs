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

namespace DustInTheWind.ConsoleTools.Tests.TabularData.DataCellTests
{
    [TestFixture]
    public class ConstructorObjectTests
    {
        private DataCell dataCell;

        private class Content
        {
            public override string ToString()
            {
                return "content";
            }
        }

        [SetUp]
        public void SetUp()
        {
            Content content = new Content();
            dataCell = new DataCell(content);
        }

        [Test]
        public void Content_is_the_one_provided_on_constructor()
        {
            Assert.That(dataCell.Content, Is.EqualTo(new MultilineText("content")));
        }

        [Test]
        public void IsEmpty_is_false()
        {
            Assert.That(dataCell.IsEmpty, Is.False);
        }

        [Test]
        public void HorizontalAlignment_is_Default()
        {
            Assert.That(dataCell.HorizontalAlignment, Is.EqualTo(HorizontalAlignment.Default));
        }
    }
}