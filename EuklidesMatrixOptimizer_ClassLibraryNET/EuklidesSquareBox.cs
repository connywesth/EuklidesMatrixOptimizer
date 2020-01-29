using System;

namespace EuklidesMatrixOptimizer_ClassLibraryNETStandard
{
    public class EuklidesSquareBox
    {
        private static int seed = (int)DateTime.Now.Ticks;
        private Random rand = new Random(seed++);
        public Box[,] matrix = new Box[5,5];

        public EuklidesSquareBox()
        {
            Initialize(rows:5, columns:5);
        }

        ~EuklidesSquareBox()
        {
        }

        public void Initialize(int rows, int columns)
        {
            int value = (int)rand.Next(1,9);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    seed+=143;
                    value = (int)rand.Next(1, 10);
                    matrix[row, column] = new Box(row:row, column:column, value:value);
                }
            }
        }

        public Box Up(Box box)
        {
            Box newBox = null;
            int row = box.Row;
            int column = box.Column;
            row--;
            try
            {
                newBox = matrix[row,column];
            }
            catch
            { 
            }
            return newBox;
        }

        public Box Right(Box box)
        {
            Box newBox = null;
            int row = box.Row;
            int column = box.Column;
            column++;
            try
            {
                newBox = matrix[row, column];
            }
            catch
            {
            }
            return newBox;
        }

        public Box Left(Box box)
        {
            Box newBox = null;
            int row = box.Row;
            int column = box.Column;
            column--;
            try
            {
                newBox = matrix[row, column];
            }
            catch
            {
            }
            return newBox;
        }

        public Box Down(Box box)
        {
            Box newBox = null;
            int row = box.Row;
            int column = box.Column;
            row++;
            try
            {
                newBox = matrix[row, column];
            }
            catch
            {
            }
            return newBox;
        }
    }
}
