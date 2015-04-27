using System;
using System.CodeDom.Compiler;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Nonograms.GameEngine;

namespace Nonograms.GameEngine.Test
{
    [TestClass]
    public class MarginsTest
    {

        [TestMethod]
        public void TestLeftInitialization()
        {
            int[,] ints = 
            {
                {3,5,3,2,3,4},
                {3,2,3,5,3,2},
                {3,4,3,2,3,4},
                {2,3,4,2,1,2}
            };
            MarginCell[][] expected = 
            {
                new[]{new MarginCell(3,3),new MarginCell(1,2) },
                new[]{new MarginCell(1,5),new MarginCell(1,2),new MarginCell(1,4),new MarginCell(1,3) },
                new[]{new MarginCell(3,3),new MarginCell(1,4)}, 
                new[]{new MarginCell(1,2),new MarginCell(1,5),new MarginCell(2,2)},
                new[]{new MarginCell(3,3),new MarginCell(1,1)}, 
                new[]{new MarginCell(1,4),new MarginCell(1,2),new MarginCell(1,4),new MarginCell(1,2) }
            };
            Margins m = new Margins(ints);
            for (int i = 0; i < expected.Length; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j].Number,m.Left[i][j].Number);
                    Assert.AreEqual(expected[i][j].Color, m.Left[i][j].Color);
                }   
            }
        }
        [TestMethod]
        public void TestTopInitialization()
        {
            int[,] ints = 
            {
                {3,5,2,2,3,3},
                {3,2,2,5,1,1},
                {3,2,2,2,2,4},
                {1,1,4,2,1,2}
            };
            MarginCell[][] expected = 
            {
                new[]{new MarginCell(1,3),new MarginCell(1,5), new MarginCell(2,2),new MarginCell(2,3) },
                new[]{new MarginCell(1,3),new MarginCell(2,2),new MarginCell(1,5),new MarginCell(2,1) },
                new[]{new MarginCell(1,3),new MarginCell(4,2), new MarginCell(1,4) }, 
                new[]{new MarginCell(2,1),new MarginCell(1,4),new MarginCell(1,2),new MarginCell(1,1),new MarginCell(1,2)  }
            };
            Margins m = new Margins(ints);
            for (int i = 0; i < expected.Length; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j].Number, m.Top[i][j].Number);
                    Assert.AreEqual(expected[i][j].Color, m.Top[i][j].Color);
                }
            }
        }
        [TestMethod]
        public void TestGetColors()
        {
            int[,] ints = 
            {
                {3,5,3,3,3,5},
                {5,3,3,5,3,5},
                {3,5,3,3,3,3},
                {3,3,5,3,5,3}
            };
            List<int> expected = new List<int>();
            expected.Add(3);
            expected.Add(5);
            Margins m = new Margins(ints);
            CollectionAssert.AreEqual(expected,m.Colors);
        }
    }
}
