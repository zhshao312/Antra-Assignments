using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class Spiral
    {
        public void PrintSpiral(int[,] matrix, int row, int column)
        {
            int rowStart = 0;
            int rowEnd = row - 1;
            int colStart = 0;
            int colEnd = column - 1;

            while (colStart <= colEnd && rowStart <= rowEnd)
            {
                for (int i = colStart; i < colEnd; i++)
                    Console.Write((matrix[rowStart, i])+" "); 

                for (int i = rowStart; i < rowEnd; i++)
                    Console.Write(matrix[i,colEnd] + " ");

                for (int i = colEnd; i > colStart; i--)
                    Console.Write(matrix[rowEnd,i] + " ");

                for (int i = rowEnd; i > rowStart; i--)
                    Console.Write(matrix[i,colStart] + " ");

                rowStart++;
                colEnd--;
                rowEnd--;
                colStart++;

            }
        }
    }
}
