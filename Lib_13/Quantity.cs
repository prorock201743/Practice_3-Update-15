using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibArray;

namespace Lib_13
{
    public static class Quantity
    {
        public static string CountOfNumbers(this MyArray myarray)
        {
            int kol = 0;
            List<int> str = new List<int>();
            double sum = 0;
            double[] average = new double[myarray.RowLength];

            for (int i = 0; i < myarray.RowLength; i++)
            {
                sum = 0;
                for (int j = 0; j < myarray.ColumnLength; j++)
                {
                    sum += myarray[i, j];
                }
                str.Add(kol);
                kol = 0;
                average[i] = (sum / myarray.ColumnLength);

                for (int j = 0; j < myarray.ColumnLength; j++)
                {
                    if (average[i] > myarray[i, j])
                    {
                        kol++;
                    }
                }
            }
            str.Add(kol);
            str.Remove(0);
            return string.Join(" ", str);
        }
    }
}
