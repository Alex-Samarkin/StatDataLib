using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatDataLib
{
    /// <summary>
    /// Represents column header
    /// </summary>
    public class HeadBase
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Col";
        public string Description { get; set; } = string.Empty;
        public HeadBase() { }
        public HeadBase(int id,string name="Col",string descriprion = "")
        {
            Id=id;
            Name=name;
            Description=descriprion;
        }
    }
}
