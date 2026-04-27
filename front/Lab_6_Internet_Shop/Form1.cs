using System.Windows.Forms;
using Lab_6_Internet_Shop.DTO;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_6_Internet_Shop
{
    /// <summary>
    /// Главная форма интернет-магазина
    /// </summary>
    public partial class Form1 : Form
    {

        private ApiService _api;

        private List<ProductDto> _currentProducts;

        private ClientInfoDto _currentClient;

        private Form2 _form2;

        private bool _isForm2Initialized;



        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _api = new ApiService();
            Products.SelectedIndexChanged += Products_SelectedIndexChanged;

            InitializeForm2();
            this.Load += Form1_Load;
        }

        /// <summary>
        /// Инициализация формы аккаунта
        /// </summary>
        private void InitializeForm2()
        {
            _form2 = new Form2();
            _form2.TopLevel = false;
            _form2.FormBorderStyle = FormBorderStyle.None;
            _form2.Dock = DockStyle.Fill;
            _form2.LoginRequested += Form2_LoginRequested;
            Acc_tab.Controls.Add(_form2);
            _form2.Show();
            _isForm2Initialized = true;
        }

        /// <summary>
        /// Обработчик запроса на авторизацию
        /// </summary>
        private async void Form2_LoginRequested()
        {
            using (Form3 loginForm = new Form3())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    _currentClient = loginForm.LoggedInClient;
                    _form2.SetAccount(_currentClient);
                }
            }
        }

        /// <summary>
        /// Обновление списка товаров
        /// </summary>
        private async Task RefreshProducts()
        {
            _currentProducts = await _api.GetProductsAsync();
            Products.DataSource = null;
            Products.DataSource = _currentProducts;
            Products.DisplayMember = "Name";
        }

        /// <summary>
        /// Обработчик изменения выбранного товара
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Products.SelectedIndex != -1 && _currentProducts != null)
            {
                var product = _currentProducts[Products.SelectedIndex];
                Description.Text = product.Description; // у товара есть описание
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
        private async void buy_button_Click(object sender, EventArgs e)
        {
            if (_currentClient == null)
            {
                MessageBox.Show("Войдите в аккаунт!");
                return;
            }
            if (Products.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар!");
                return;
            }

            var selectedProduct = _currentProducts[Products.SelectedIndex];
            // Для простоты покупаем 1 штуку. Позже можете добавить NumericUpDown.
            var items = new List<(int productId, int count)>
        {
            (selectedProduct.Id, 1)
        };

            bool success = await _api.PurchaseAsync(_currentClient.Id, items);
            if (success)
            {
                MessageBox.Show($"Товар \"{selectedProduct.Name}\" куплен!");
                // Обновляем данные клиента (баланс, покупки) и список товаров
                await RefreshClientData();
                await RefreshProducts();
                _form2.RefreshPurchases(); // обновить список покупок в Form2
            }
            else
            {
                MessageBox.Show("Ошибка при покупке. Возможно, недостаточно средств или товара.");
            }
        }

        private async Task RefreshClientData()
        {
            // Получаем свежие данные клиента с сервера
            var updatedClient = await _api.GetClientInfoAsync(_currentClient.Id);
            if (updatedClient != null)
            {
                _currentClient = updatedClient;
                _form2.SetAccount(_currentClient);
            }
        }


        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            await RefreshProducts();
        }
    }


}