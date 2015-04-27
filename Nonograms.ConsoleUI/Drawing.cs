using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nonograms.GameEngine;

namespace Nonograms.ConsoleUI
{
    internal class Drawing
    {
        #region Variables

        private int _posX;
        private int _posY;
        private int _sizeX;
        private int _sizeY;
        private Margins _margins;
        private MarginCell[][] _top;
        private MarginCell[][] _left;
        private int[,] _field;
        private int _spareCellColor;
        
        #endregion

        #region Properties

        public List<int> Colors { get; set; }

        #endregion


        #region Constructors

        public Drawing(int pos_x, int pos_y, int[,] array)
        {
            _posX = pos_x;
            _posY = pos_y;
            _field = array;
            _sizeX = array.GetLength(1);
            _sizeY = array.GetLength(0);
            _margins = new Margins(array);
            _top = _margins.Left;
            _left = _margins.Top;
            Colors = _margins.Colors; 
            _spareCellColor = 0;
        }

        public Drawing(int pos_x, int pos_y, int[,] array, int spareCellColor)
        {
            _posX = pos_x;
            _posY = pos_y;
            _field = array;
            _sizeX = array.GetLength(1);
            _sizeY = array.GetLength(0);
            _margins = new Margins(array);
            _top = _margins.Top;
            _left = _margins.Left;
            _spareCellColor = spareCellColor;
        }

        #endregion


        #region Methods


        public void DrawField()
        {
            Console.SetCursorPosition(_posX, _posY);
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                Console.SetCursorPosition(_posX, _posY + i);
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    Console.BackgroundColor = (ConsoleColor) _field.GetValue(i, j);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        public void DrawEmptyField()
        {
            Console.SetCursorPosition(_posX, _posY);
            for (int i = 0; i < _sizeX; i++)
            {
                Console.SetCursorPosition(_posX, _posY + i);
                for (int j = 0; j < _sizeY - 1; j++)
                {
                    if ((i + j)%2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }
                }
            }

        }

        public void DrawMargins()
        {
            for (int i = 0; i < _top.Length; i++)
            {
                for (int j = 0; j < _top[i].Length; j++)
                {
                    if (_top[i][j].Color != _spareCellColor)
                    {
                        if (_top[i][j].Number > 9)
                        {
                            Console.SetCursorPosition(_posX + i, _posY - j - 2);
                            Console.BackgroundColor = (ConsoleColor) _top[i][j].Color;
                            Console.Write("{0}", _top[i][j].Number.ToString()[0]);
                            Console.SetCursorPosition(_posX + i, _posY - j - 1);
                            Console.BackgroundColor = (ConsoleColor) _top[i][j].Color;
                            Console.Write("{0}", _top[i][j].Number.ToString()[1]);
                            continue;
                        }
                        Console.SetCursorPosition(_posX + i, _posY - j - 1);
                        Console.BackgroundColor = (ConsoleColor) _top[i][j].Color;
                        Console.Write("{0}", _top[i][j].Number);
                    }
                }
            }
            for (int i = 0; i < _left.Length; i++)
            {
                for (int j = 0; j < _left[i].Length; j++)
                {
                    if (_left[i][j].Color != _spareCellColor)
                    {
                        if (_left[i][j].Number > 9)
                        {
                            Console.SetCursorPosition(_posX - j - 1, _posY + i);
                            Console.BackgroundColor = (ConsoleColor) _left[i][j].Color;
                            Console.Write("{0}", _left[i][j].Number.ToString()[1]);
                            Console.SetCursorPosition(_posX - j - 2, _posY + i);
                            Console.BackgroundColor = (ConsoleColor) _left[i][j].Color;
                            Console.Write("{0}", _left[i][j].Number.ToString()[0]);
                            continue;
                        }
                        Console.SetCursorPosition(_posX - j - 1, _posY + i);
                        Console.BackgroundColor = (ConsoleColor) _left[i][j].Color;
                        Console.Write("{0}", _left[i][j].Number);
                    }
                }
            }
        }

        public void ChangeColor(int colorPrevious, int colorPrefered)
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    if (_field[i,j] == colorPrevious)
                    {
                        _field[i, j] = colorPrefered;
                    }
                }
            }
            _margins = new Margins(_field);
            _top = _margins.Left;
            _left = _margins.Top;
        }
        
        #endregion

    }
}
