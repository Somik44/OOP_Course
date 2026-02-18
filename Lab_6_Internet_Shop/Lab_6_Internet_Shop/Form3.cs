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
    /// Форма авторизации пользователя
    /// </summary>
    public partial class Form3 : Form
    {
        /// <summary>
        /// Список зарегистрированных аккаунтов
        /// </summary>
        private List<Account> accounts;

        private int index = -1;

        /// <summary>
        /// Конструктор формы авторизации
        /// </summary>
        /// <param name="accounts">Список аккаунтов для проверки</param>
        public Form3(List<Account> accounts)
        {
            InitializeComponent();
            this.accounts = accounts;

            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;

            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;

            textBox1.Text = "login";
            textBox1.ForeColor = Color.Gray;

            textBox2.Text = "password";
            textBox2.ForeColor = Color.Gray;
            textBox2.UseSystemPasswordChar = false;

            this.Text = "Login";
        }

        /// <summary>
        /// Обработчик нажатия кнопки входа
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            bool checker = false;

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Login == textBox1.Text && accounts[i].Password == textBox2.Text)
                {
                    checker = true;
                    index = i;
                    break;
                }
            }

            if (checker)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("Не верный логин или пароль!!!");
        }

        /// <summary>
        /// Обработчик нажатия кнопки отмены
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Получение индекса авторизованного пользователя
        /// </summary>
        /// <returns>Индекс пользователя в списке аккаунтов</returns>
        public int get_index()
        {
            return index;
        }

        /// <summary>
        /// Обработчик входа в поле логина
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }

        /// <summary>
        /// Обработчик выхода из поля логина
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void textBox1_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Login";
                textBox1.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Обработчик входа в поле пароля
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox2.Clear();
            textBox2.ForeColor = Color.Black;
        }

        /// <summary>
        /// Обработчик выхода из поля пароля
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void textBox2_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}