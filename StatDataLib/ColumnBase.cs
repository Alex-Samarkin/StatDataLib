using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StatDataLib
{
    /// <summary>
    /// Represents column with data
    public class ColumnBase<T> : HeadBase
    {
        public T Default { get; set; } = default;
        public List<T> Values { get; set; } = new List<T>();
        public int Count => Values.Count;
        public bool AutoExpand = false;

        public ColumnBase<T> Resize(int size = 0)
        {
            size = size < 0 ? -size : size;

            if (size == 0 || Count == size) return this;
            if (size > Count)
            {
                // Add size-Count default value to the Values array
                Values.AddRange( Enumerable.Repeat(Default,size-Count));
            }
            else
            {
                Values.RemoveRange(size, Count);

            }
            return this;
        }
        public ColumnBase<T> Clear() { Values.Clear(); return this; }
        public ColumnBase<T> Add(T value) { Values.Add(value); return this; }
        public ColumnBase<T> Fill(T value = default) 
        {
            var c = Count;
            Values.Clear();
            Values.AddRange(Enumerable.Repeat(value, c));
            return this; 
        }
        public ColumnBase<T> Fill(int n,T value = default)
        {
            Values.Clear();
            Values.AddRange(Enumerable.Repeat(value, n));
            return this;
        }

        public T Get(int index)
        {
            if (AutoExpand == false)
            {
                if (index < 0 || index >= Values.Count) return default;
                return Values[index];
            }
            Resize(index);
            return Values[index];
        }
        public ColumnBase<T> Set(int index,T value)
        {
            if (AutoExpand == false)
            {
                if (index < 0 || index >= Values.Count) return this;
                Values[index] = value;
            }
            else
            {
                Resize(index);
            }
            Values[index] = value;
            return this;
        }


    }
}
