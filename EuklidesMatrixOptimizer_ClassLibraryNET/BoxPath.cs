using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EuklidesMatrixOptimizer_ClassLibraryNETStandard
{
    public class BoxPath : List<Box>
    {
        public int Sum()
        {
            int sum = 0;
            foreach (Box box in this)
            {
                sum += box.Value;
            }
            return sum;
        }

        public BoxPath Clone()
        {
            BoxPath newBoxPath = new BoxPath();
            newBoxPath.AddRange(this);
            return newBoxPath;
        }

        public bool IsFoundBox(Box box)
        {
            bool found = false;
            foreach (Box b in this)
            {
                if (box.Row==b.Row && box.Column==b.Column)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }



        public override string ToString()
        {
            string boxPath = "";
            foreach(Box box in this)
            {
                if ("" == boxPath)
                {
                    boxPath += $", ";
                }
                boxPath += $"{box}";
            }
            return boxPath;
        }
    }
}
