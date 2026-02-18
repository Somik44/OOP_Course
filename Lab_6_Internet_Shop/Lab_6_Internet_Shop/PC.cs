using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Internet_Shop
{
    internal class PC : Product
    {
        public string Name { get; }
        public float Price { get; }
        private string Processor { get; set; }
        



        public PC(string name, float price, string processor)
        {
            Name = name;
            Price = price;
            Processor = processor;
        }

        public string get_Description()
        {
            string description = $"Модель: {Name}" +
                $"\r\nЦена: {Price}" +
                $"\r\nПроцессор: {Processor}";

            return description;
        }


    }
}
