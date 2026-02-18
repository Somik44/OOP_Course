using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_6_Internet_Shop
{
    /// <summary>
    /// Главная форма интернет-магазина
    /// </summary>
    public partial class Form1 : Form
    {

        private List<Product> products = new List<Product> {
            new TV("Samsung U2", 150000, 85),
            new TV("Sony M15", 40000, 42),
            new PC("Ardor S1", 80000, "Intel Core I7-11700f")
        };

        private List<Account> accounts = new List<Account>
        {
            new Account("login1", "1234", "Вася Петров", 200000),
            new Account("login2", "1111", "Иван Пузан", 85000)
        };

        private Form2 form2;

        private bool isForm2Initialized = false;

        Account now_account;

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            RefreshListBox();

            this.Text = "DNS";

            Products.SelectedIndexChanged += Products_SelectedIndexChanged;
            InitializeForm2();
        }

        /// <summary>
        /// Инициализация формы аккаунта
        /// </summary>
        private void InitializeForm2()
        {
            form2 = new Form2();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;

            form2.LoginRequested += Form2_LoginRequested;
            Acc_tab.Controls.Add(form2);
            form2.Show();
            isForm2Initialized = true;
        }

        /// <summary>
        /// Обработчик запроса на авторизацию
        /// </summary>
        private void Form2_LoginRequested()
        {
            using (Form3 log = new Form3(accounts))
            {
                if (log.ShowDialog() == DialogResult.OK)
                {
                    now_account = accounts[log.get_index()];
                    form2.SetAccount(now_account);
                }
            }
        }

        /// <summary>
        /// Обновление списка товаров
        /// </summary>
        private void RefreshListBox()
        {
            Products.DataSource = null;
            Products.DataSource = products;
            Products.DisplayMember = "Name";
        }

        /// <summary>
        /// Обработчик изменения выбранного товара
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Products.SelectedIndex != -1)
            {
                Description.Text = products[Products.SelectedIndex].get_Description();
            }
            else
            {
                Description.Text = "Товар не выбран";
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки покупки
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void buy_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (isForm2Initialized && Products.SelectedIndex != -1)
                {
                    var selectedProduct = products[Products.SelectedIndex];

                    if (!now_account.CanAfford(selectedProduct.Price))
                    {
                        MessageBox.Show("Недостаточно средств на счете!");
                        return;
                    }

                    if (now_account.DeductBalance(selectedProduct.Price))
                    {
                        now_account.add_Purchases(new Purchase(selectedProduct.Name, selectedProduct.Price));
                        MessageBox.Show($"Куплен {selectedProduct.Name}");
                        form2.RefreshPurchases();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при списании средств!");
                    }
                }
                else
                {
                    MessageBox.Show("Товар не выбран!");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Войдите в аккаунт!");
            }
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }


}