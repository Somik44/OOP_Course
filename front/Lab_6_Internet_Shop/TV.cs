using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Internet_Shop
{
    internal class TV : Product
    {
        public string Name { get; }
        public float Price { get; }
        private float Diagonal { get; set;}


        

        public TV(string name, float price, float diagonal)
        {
            Name = name;
            Price = price;
            Diagonal = diagonal;
        }

        public string get_Description()
        {
            string description = $"Модель: {Name}" +
                $"\r\nЦена: {Price}" +
                $"\r\nДиагональ: {Diagonal}''";

            return description;
        }


    }
}
