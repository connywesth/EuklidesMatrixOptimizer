using System;
using System.Collections.Generic;
using System.Text;

namespace EuklidesMatrixOptimizer_ClassLibraryNETStandard
{
    public class Box
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Value { get; private set; }

        public Box(int row, int column, int value)
        {
            Validate(row: row, column: column, value:value);

            this.Row = row;
            this.Column = column;
            this.Value = value;
        }

        public void Validate(int row, int column, int value)
        {
            if (row < 0 || row > 4)
            {
                throw new IndexOutOfRangeException("Parameter [row] can only have values from 1 to 5.");
            }
            if (column < 0 || row > 4)
            {
                throw new IndexOutOfRangeException("Parameter [column] can only have values from 1 to 5.");
            }
            if (value < 1 || value > 9)
            {
                throw new Exception("Parameter [value] can only have values from 1 to 9.");
            }
        }

        public override string ToString()
        {
            return $"([{this.Row},{this.Column}]:{this.Value})";
        }

    }
}
