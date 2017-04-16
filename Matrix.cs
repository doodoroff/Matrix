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
        delegate void MatrixLancher();
        
        public void MatrixStart()
        {
            for (int i = 0; i < (Console.WindowWidth - 1)/2 ; i++) 
            {
                new Thread(new Matrix().StringDrop).Start(i*2);
                Thread.Sleep(new Random().Next(3, 4) * 10);
            }

            Thread.Sleep(new Random().Next(5, 10) * 10);

            for (int i = 0; i < (Console.WindowWidth - 1)/2; i++)
            {
                new Thread(new Matrix().StringDrop).Start(i*2);
                Thread.Sleep(new Random().Next(3, 4) * 10);
            }

            Thread.Sleep(new Random().Next(5, 10) * 10);

            for (int i = 0; i < (Console.WindowWidth - 1) / 2; i++)
            {
                new Thread(new Matrix().StringDrop).Start(i * 2);
                Thread.Sleep(new Random().Next(3, 4) * 10);
            }
        }
         

        void StringDrop(object position)
        {
            while (true)
            {
                int stringLength = new Random().Next(3, 12);
                for (int q = 0; q < Console.WindowHeight - stringLength - 2; q++)
                {
                    lock (block)
                    {
                        Console.SetCursorPosition((int)position, q);
                        Console.WriteLine(" ");
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

                            Console.SetCursorPosition((int)position, Console.CursorTop);
                            Console.WriteLine(matrixChar[new Random().Next(0, 36)]);
                            Thread.Sleep(5);

                            if (Console.CursorTop == Console.WindowHeight - 2)
                            {
                                for (int t = Console.WindowHeight - stringLength - 3; t < Console.WindowHeight; t++)
                                {
                                    Console.SetCursorPosition((int)position, t);
                                    Console.WriteLine(" ");
                                    Thread.Sleep(5);
                                }
                            }
                        }
                    } // end lock
                } // end for
            } // end while
        } // end StringDrop
    }
}
