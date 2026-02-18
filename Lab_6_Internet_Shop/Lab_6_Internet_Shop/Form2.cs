using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Account account;

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
        /// Конструктор формы аккаунта с предустановленным аккаунтом
        /// </summary>
        /// <param name="account">Аккаунт пользователя</param>
        public Form2(Account account) : this()
        {
            SetAccount(account);
        }

        /// <summary>
        /// Установка текущего аккаунта
        /// </summary>
        /// <param name="account">Аккаунт пользователя</param>
        public void SetAccount(Account account)
        {
            this.account = account;

            if (account != null)
            {
                ShowUserInterface();
                Name_Text.Text = account.Name;
                RefreshListBox();
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
            if (account != null)
            {
                RefreshListBox();
            }
        }

        /// <summary>
        /// Обновление ListBox с покупками
        /// </summary>
        private void RefreshListBox()
        {
            if (account != null)
            {
                Purchases.DataSource = null;
                Purchases.DataSource = account.get_list();
                Purchases.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// Обработчик изменения выбранной покупки
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void Purchases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (account != null && Purchases.SelectedIndex != -1)
            {
                Purch_text.Text = account.get_list()[Purchases.SelectedIndex].get_Description();
            }
            else
            {
                Purch_text.Text = "Не выбран товар";
            }
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