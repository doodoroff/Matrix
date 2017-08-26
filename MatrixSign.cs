using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixSign
    {
        MatrixChar outputChar = new MatrixChar();
        Random randomInt = new Random();
        ConsoleColor signColor;
        bool signIsEmpty;

        public MatrixSign()
        {
            this.signIsEmpty = false;
            // initialize fields
        }

        public string Sign
        {
            get
            {
                if (signIsEmpty)
                {
                    return " ";
                }
                else
                {
                    return outputChar[randomInt.Next(0, 36)];
                }
            }
        }

        public bool SignIsEmpty
        {
            set { this.signIsEmpty = value; }
        }

        public ConsoleColor SignColor
        {
            get { return this.signColor; }
        }

        public void SetWhiteColor()
        {
            signColor = ConsoleColor.White;
        }

        public void SetGreenColor()
        {
            signColor = ConsoleColor.Green;
        }

        public void SetDarkGreenColor()
        {
            signColor = ConsoleColor.DarkGreen;
        }
    }
}
