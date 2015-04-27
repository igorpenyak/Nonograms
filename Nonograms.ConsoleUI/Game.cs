using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Nonograms.GameEngine;

namespace Nonograms.ConsoleUI
{
    class Game
    {
        #region Variables

        private int pos_X = 20;
        private int pos_Y = 10;
        private int _consoleBufferSizeX = 500;
        private int _consoleBufferSizeY = 500;
        private int _consoleWindowSizeX = 58;
        private int _consoleWindowSizeY = 58;
        private static string[] _files = Directory.GetFiles(@"nonograms/");
        private List<int[,]> _nonograms = NonogramsInit();
        private int _choosenNonogram;
        private Drawing _drawing;

        #endregion

        #region Constructors

        public Game()
        {
            ConsoleMenu();
        }

        #endregion


        private static List<int[,]> NonogramsInit()
        {
            List<int[,]> nonograms = new List<int[,]>();
            NonogramsReader nr;
            for (int i = 0; i < _files.Length; i++)
            {
                nr = new NonogramsReader(_files[i]);
                nonograms.Add(nr.Nonogram);
            }
            return nonograms;
        }

        private void ConsoleMenu()
        {
            ConsoleMenuInitInfo();
            ConsoleMenuHandling();
            ConsoleInit(_nonograms[_choosenNonogram]);
            ConsoleHandling();
        }

        private void ConsoleHandling()
        {
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.CursorTop--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.CursorLeft++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.CursorTop++;
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.G:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case ConsoleKey.B:
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case ConsoleKey.S:
                        _drawing.DrawField();
                        break;
                    case ConsoleKey.K:
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case ConsoleKey.M: 
                        ConsoleMenu();
                        break;
                    default: Console.Write(" ");
                        break;
                }              
            }

        }

        private void ConsoleMenuInitInfo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("-------------------Nonograms---------------------");
            Console.WriteLine();
            Console.WriteLine("Головоломки:");
            for (int i = 0; i < _files.GetLength(0); i++)
            {
                Console.WriteLine("{0}. {1}", i, _files[i]);
            }
        }

        private void ConsoleMenuHandling()
        {
            _choosenNonogram = 0;
            try
            {
                _choosenNonogram = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильне введення. Введіть будь ласка тільки номер головоломки.");
                ConsoleMenu();
            }
            if (_choosenNonogram > _files.Count())
            {
                Console.WriteLine("Головоломки під таким номером не існує.");
                ConsoleMenu();
            }                
        }

        private void ConsoleInit(int[,] consoleColor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.SetBufferSize(_consoleBufferSizeX, _consoleBufferSizeY);
            Console.SetWindowSize(_consoleWindowSizeX, _consoleWindowSizeY);
            _drawing = new Drawing(pos_X, pos_Y, consoleColor);
            //Змінюю кольои головоломки, бо наново переписувати головоломку дуже влом
            _drawing.ChangeColor(11, 9);
            _drawing.ChangeColor(10, 2);
            _drawing.DrawMargins();
            _drawing.DrawEmptyField();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Будь ласка виберіть колір малювання");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" - B");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" - G");
            Console.WriteLine("BlacK - K");
            Console.WriteLine("Menu - M");
            Console.WriteLine("Show solved - S");
        }
    }
}

