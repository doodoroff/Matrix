using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Matrix
{
    class MatrixDirector
    {
        MatrixColumn column = new MatrixColumn();
        MatrixSign[] droppingColumn = new MatrixSign[0];
        static Object block = new object();
        int indention = 3;

        public void MatrixStart()
        {
            for (int i = 0; i < (Console.WindowWidth - 1) / 2; i++)
            {
                new Thread(new MatrixDirector().DropColumn).Start(i * 2);
                Thread.Sleep(new Random().Next(1, 8) * 10);
            }
        }

        void DropColumn(object horisontalPosition)
        {
            while (true)
            {
                while (droppingColumn.Length <= Console.WindowHeight - indention)
                {
                    PrintColumn((int)horisontalPosition, false);
                }

                PrintColumn((int)horisontalPosition, true);
            }
        }

        void PrintColumn(int horisontalPosition, bool columnIsNotGrowing)
        {
            droppingColumn = column.CreateColumn(columnIsNotGrowing);
            for (int i = 0; i < droppingColumn.Length; i++)
            {
                lock (block)
                {
                    Console.SetCursorPosition(horisontalPosition, i);
                    Console.ForegroundColor = droppingColumn[i].SignColor;
                    Console.WriteLine(droppingColumn[i].Sign);
                    Thread.Sleep(1);
                }
            }
        }
    }
}
