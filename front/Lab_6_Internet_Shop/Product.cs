using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Internet_Shop
{
    public interface Product
    {
        public string Name { get; }

        public float Price { get; }

        public string get_Description();
    }
}
