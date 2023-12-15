using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatDataLib
{
    public class DoubleColumn : ColumnBase<double>
    {
        public double this[int index]
        {
            get
            {
                /* return the specified index here */
                return base.Get(index);
            }
            set
            {
                /* set the specified index to value here */
                base.Set(index, value);
            }
        }
        /*
        public IntColumn Fill(int value, int n)
        {
            base.Fill(value, n);
            return this;
        }
        */
        public DoubleColumn Zeros(int n) => (DoubleColumn)Fill(n, 0);
        public DoubleColumn Ones(int n) => (DoubleColumn)Fill(n, 1);
        public DoubleColumn Seq(double start, double step = 1)
        {
            Set(0, start);
            for (int i = 1; i < Count; i++)
            {
                base.Set(i, base.Get(i - 1) + step);
            }
            return this;
        }
        public DoubleColumn Random(double from, double to, Random r = null)
        {
            r = r ?? new Random();
            var h = from - to;
            for (int i = 0; i < Count; i++)
            {
                base.Set(i, from + r.NextDouble()*h);
            }
            return this;
        }

    }
}
