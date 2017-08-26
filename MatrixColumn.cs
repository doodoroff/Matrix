using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixColumn
    {
        MatrixSignContainer column = new MatrixSignContainer();
        Random randomInt = new Random();
        int rangeSize = 0;
        int outputSignsCounter = 0;
        bool emptyRange = true;
        int rangeSizeContainer;

        void FillColumn()
        {
            if (rangeSize <= 0)
            {
                rangeSize = randomInt.Next(3, 8);
                rangeSizeContainer = rangeSize;
            }

            if (emptyRange)
            {
                rangeSize--;
                MatrixSign localMatrixSign = new MatrixSign();
                if (rangeSize == 0)
                {
                    emptyRange = false;
                }
                localMatrixSign.SignIsEmpty = true;
                column.AddSign(localMatrixSign);
            }
            else
            {
                MatrixSign LocalMatrixSign = new MatrixSign();

                if (rangeSize == rangeSizeContainer)
                {
                    LocalMatrixSign.SetWhiteColor();
                }
                else if (rangeSize == rangeSizeContainer - 1)
                {
                    LocalMatrixSign.SetGreenColor();
                }
                else
                {
                    LocalMatrixSign.SetDarkGreenColor();
                }

                rangeSize--;

                if (rangeSize == 0)
                {
                    emptyRange = true;
                }
                LocalMatrixSign.SignIsEmpty = false;
                column.AddSign(LocalMatrixSign);
            }
        }

        public MatrixSign[] CreateColumn(bool isColumnLengthEqlWindowHeght)
        {
            FillColumn();

            MatrixSign[] outputColumn = new MatrixSign[outputSignsCounter];

            if (isColumnLengthEqlWindowHeght)
            {
                column.RemoveLastSign();
            }
            // ATTENTION ! first element in array is missing in first call of method because of "for" condition
            for (int i = 0; i < outputColumn.Length; i++)
            {
                outputColumn[i] = column[i];
            }

            if (!isColumnLengthEqlWindowHeght)
            {
                outputSignsCounter++;
            }

            return outputColumn;
        }
    }
}
