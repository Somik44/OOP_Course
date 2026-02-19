using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Internet_Shop
{
    public class Purchase : Product
    {
        public string Name { get; }

        public float Price { get; }

        private DateTime Date {  get; set; }

        public Purchase(string name, float price) {
            Name = name;
            Price = price;
            Date = DateTime.Now;
        }

        public string get_Description()
        {
            string description = $"Модель: {Name}" +
                $"\r\nЦена: {Price}" +
                $"\r\nДата: {Date}";

            return description;
        }
    }
}
