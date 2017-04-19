using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Matrix
{
    class Matrix
    {
        ICharProvider matrixChar = new CharProvider();
        static Object block = new Object();
        int stringLength;
        
        public void MatrixStart()
        {
            for (int i = 0; i < (Console.WindowWidth - 1)/2 ; i++) 
            {
                new Thread(new Matrix().StringDrop).Start(i*2);
                Thread.Sleep(new Random().Next(1, 4) * 10);
            }
        }
         

        void StringDrop(object position)
        {
            while (true)
            {
                stringLength = new Random().Next(3, 12);
                for (int q = 1; q < Console.WindowHeight; q++)
                {
                    lock (block)
                    {   
                        if (q < Console.WindowHeight-stringLength-1)
                        {
                            Console.SetCursorPosition((int)position, q);
                            Console.WriteLine(" ");
                            CreateColumn(position);
                            Thread.Sleep(1);
                        }
                        else
                        {
                            Console.SetCursorPosition((int)position, q);
                            Console.WriteLine(" ");
                            CreateColumnDisappiering(position);
                            Thread.Sleep(1);
                        }
                    } // end lock
                } // end for
            } // end while
        } // end StringDrop

        void CreateColumn(object cursorLinePosition)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < stringLength; i++)
            {
                if (i == stringLength - 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (i == stringLength - 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition((int)cursorLinePosition, Console.CursorTop);
                Console.WriteLine(matrixChar[new Random().Next(0, 36)]);
                Thread.Sleep(5);
            }
        }

        void CreateColumnDisappiering(object cursorLinePosition)
        {
            CreateShorterColumn(cursorLinePosition);
            stringLength--;
        }

        void CreateShorterColumn(object cursorLinePosition)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = stringLength; i > 0; i--)
            {
                Console.SetCursorPosition((int)cursorLinePosition, Console.CursorTop);
                Console.WriteLine(matrixChar[new Random().Next(0, 36)]);
                Thread.Sleep(5);
            }
        }
    }
}
