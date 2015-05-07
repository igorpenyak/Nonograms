using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonograms.GameEngine
{
    public class Margins
    {
        #region Variables

        public MarginCell[][] Top { get; private set; }
        public MarginCell[][] Left { get; private set; }
        public List<int> Colors { get;private set; }

        #endregion


        #region Constructors

        public Margins(int[,] array)
        {
            TopInitialization(array);
            LeftInitialization(array);
            Colors = GetColors(array);
        }

        #endregion

        #region Methods

        private void TopInitialization(int[,] grid)
        {
            Top = new MarginCell[grid.GetLength(0)][];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                var tempArr = CreateMargin(CopyLineVert(grid, i));
                Top[i] = new MarginCell[tempArr.Count];
                tempArr.CopyTo(Top[i]);
            }
        }

        private void LeftInitialization(int[,] grid)
        {
            Left = new MarginCell[grid.GetLength(1)][];
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                var tempArr = CreateMargin(CopyLineHor(grid, i));
                Left[i] = new MarginCell[tempArr.Count];
                tempArr.CopyTo(Left[i]);
            }
        }

        private static List<MarginCell> CreateMargin(int[] line)
        {
            // Review remark from IP:
            // думаю, не зовсім вдало використовувати настільки скорочені імена змінних ...
            int c = (int) line.GetValue(0);
            int k = 1;
            List<MarginCell> tempArr = new List<MarginCell>();
            for (int i = 1; i < line.GetLength(0); i++)
            {
                if (c == (int) line.GetValue(i))
                {
                    k++;
                    if (IsEnd( line, i))
                    {
                        tempArr.Add(new MarginCell(k, (int) line.GetValue(i)));
                    }
                }
                else
                {
                    c = (int) line.GetValue(i);
                    if (IsEnd((int[]) line, i))
                    {
                        tempArr.Add(new MarginCell(k, (int) line.GetValue(i - 1)));
                        tempArr.Add(new MarginCell(1, (int) line.GetValue(i)));
                        break;
                    }
                    tempArr.Add(new MarginCell(k, (int) line.GetValue(i - 1)));
                    k = 1;
                }
            }
            return tempArr;
        }

        private static bool IsEnd(int[] array, int index)
        {
            return array.Length - 1 == index;
        }

        private static int[] CopyLineVert(int[,] array, int index)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                list.Add((int) array.GetValue(index, i));
            }
            int[] temp = new int[list.Count];
            list.CopyTo(temp);
            return temp;
        }

        private static int[] CopyLineHor(int[,] array, int index)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                list.Add((int) array.GetValue(i, index));
            }
            int[] temp = new int[list.Count];
            list.CopyTo(temp);
            return temp;
        }

        private List<int> GetColors(int[,] array)
        {
            List<int> colors = new List<int>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!colors.Contains(array[i, j]))
                    {
                        colors.Add(array[i,j]);
                    }
                }
            }
            return colors;
        }
        #endregion

    }
}
