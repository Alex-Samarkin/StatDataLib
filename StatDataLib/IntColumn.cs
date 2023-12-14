using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatDataLib
{
    public class IntColumn : ColumnBase<int>
    {
        public int this[int index]
        {
            get { 
                /* return the specified index here */ 
                return base.Get(index);
            }
            set {
                /* set the specified index to value here */
                base.Set(index,value);
            }
        }
        /*
        public IntColumn Fill(int value, int n)
        {
            base.Fill(value, n);
            return this;
        }
        */
        public IntColumn Zeros(int n) => (IntColumn)Fill(n,0);
        public IntColumn Ones(int n) => (IntColumn)Fill(n, 1);
        public IntColumn Seq(int start, int step = 1)
        {
            Set(0, start);
            for (int i = 1; i < Count; i++)
            {
                base.Set(i, base.Get(i - 1)+step);
            }
            return this;
        }
        public IntColumn Random(int from, int to, Random r = null)
        {
            r = r ?? new Random();
            for (int i = 0; i < Count; i++)
            {
                base.Set(i, r.Next(from, to));
            }
            return this;
        }
    }
}
