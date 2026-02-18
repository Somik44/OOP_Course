using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Internet_Shop
{
    public class Account
    {
        public string Login {  get; set; }
        public string Password { get; set; }

        public string Name { get; set; }

        public float Balance { get; set; }

        List<Product> products { get; set; }

        public Account(string login, string password, string name, float balance) 
        {
            Login = login;
            Password = password;
            Name = name;
            products = new List<Product>();
            Balance = balance;
        }

        public List<Product> get_list()
        {
            return products;
        }

        public void add_Purchases(Product purchase)
        {
            products.Add(purchase);
        }

        public bool CanAfford(float amount)
        {
            return Balance >= amount;
        }

        public bool DeductBalance(float amount)
        {
            if (CanAfford(amount))
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

    }
}
