using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixSignContainer
    {
        MatrixSign[] signArray = new MatrixSign[0];
        int counter = 0;

        public MatrixSign this[int index]
        {
            get { return signArray[index]; }
        }

        public int Count
        {
            get { return counter; }
        }

        public void AddSign(MatrixSign sign)
        {
            if (counter == 0)
            {
                signArray = new MatrixSign[1];
                signArray[0] = sign;
                counter = 1;
            }
            else
            {
                MatrixSign[] localArray = new MatrixSign[counter + 1];
                for (int i = 0; i < localArray.Length - 1; i++)
                {
                    localArray[i + 1] = signArray[i];
                }
                signArray = localArray;
                signArray[0] = sign;
                counter++;
            }
        }

        public void RemoveLastSign()
        {
            // TO DO: handle counter = 0 situation

            MatrixSign[] localArray = new MatrixSign[counter - 1];
            for (int i = 0; i < localArray.Length; i++)
            {
                localArray[i] = signArray[i];
            }
            signArray = localArray;
            counter--;
        }
    }
}
