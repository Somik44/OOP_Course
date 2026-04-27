using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab_6_Internet_Shop.DTO;

namespace Lab_6_Internet_Shop
{
    /// <summary>
    /// Форма отображения информации об аккаунте пользователя
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// Текущий аккаунт пользователя
        /// </summary>
        private ClientInfoDto _client;

        /// <summary>
        /// Событие запроса авторизации
        /// </summary>
        public event Action LoginRequested;

        /// <summary>
        /// Конструктор формы аккаунта
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            ShowLoginPrompt();
            Purchases.SelectedIndexChanged += Purchases_SelectedIndexChanged;
        }

        /// <summary>
        /// Установка текущего аккаунта
        /// </summary>
        /// <param name="account">Аккаунт пользователя</param>
        public void SetAccount(ClientInfoDto client)
        {
            _client = client;
            if (client != null)
            {
                ShowUserInterface();
                Name_Text.Text = client.Name;
                RefreshPurchases();
            }
            else
            {
                ShowLoginPrompt();
            }
        }

        /// <summary>
        /// Показать приглашение к авторизации
        /// </summary>
        private void ShowLoginPrompt()
        {
            loginPromptLabel.Visible = true;
            loginButton.Visible = true;
            Purchases.Visible = false;
            Purch_text.Visible = false;
            Name_Text.Visible = false;
        }

        /// <summary>
        /// Показать интерфейс пользователя
        /// </summary>
        private void ShowUserInterface()
        {
            loginPromptLabel.Visible = false;
            loginButton.Visible = false;

            Purchases.Visible = true;
            Purch_text.Visible = true;
            Name_Text.Visible = true;
        }

        /// <summary>
        /// Обработчик нажатия кнопки входа
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginRequested?.Invoke();
        }

        /// <summary>
        /// Обновление списка покупок
        /// </summary>
        public void RefreshPurchases()
        {
            if (_client != null && _client.Orders != null)
            {
                var allPurchases = _client.Orders
                    .SelectMany(o => o.Items.Select(i => new DisplayPurchase
                    {
                        Name = i.ProductName,
                        Description = $"{i.ProductName} - {i.Count} шт. по {i.PriceAtPurchase} руб. (заказ от {o.Date})"
                    }))
                    .ToList();

                Purchases.DataSource = null;
                Purchases.DataSource = allPurchases;
                Purchases.DisplayMember = "Name";
            }
            else
            {
                Purchases.DataSource = null;
                Purch_text.Text = "История покупок пуста";
            }
        }

        private void Purchases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_client != null && Purchases.SelectedItem is DisplayPurchase selected)
            {
                Purch_text.Text = selected.Description;
            }
            else
            {
                Purch_text.Text = "Не выбран товар";
            }
        }

        private class DisplayPurchase
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}