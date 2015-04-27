using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nonograms.GameEngine
{
    public class NonogramsReader
    {
        #region Properties

        public int[,] Nonogram { get; private set; }

        #endregion

        #region Constructors

        public NonogramsReader(string path)
        {
            Nonogram = ReadFromFile(path);
        }

        #endregion


        #region Helpers

        private int[,] ReadFromFile(string path)
        {
            String input = File.ReadAllText(path);
            int i = 0, j = 0;
            string[] rowsString = input.Split('\n');
            int columns = rowsString.GetLength(0);
            int rows = rowsString[0].Split(' ').Count();
            int[,] result = new int[rows, columns];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = Convert.ToInt32(col);
                    j++;
                }
                i++;
            }
            return result;
        }

        #endregion

    }
}
