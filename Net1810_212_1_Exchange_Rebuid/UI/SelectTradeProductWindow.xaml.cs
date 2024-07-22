using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Exchange.Business;
using Exchange.Data.Models;
using Exchange.WpfApp.UI;

namespace Exchange.WpfApp
{
    public partial class SelectTradeProductWindow : Window, INotifyPropertyChanged
    {
        private Customer _buyer;
        private readonly ProductsBusiness _productBusiness = new ProductsBusiness();
        private readonly CustomerBusiness _customerBusiness = new CustomerBusiness();
       
        private readonly bool createUserHaveOnly = false;
        private readonly int _userWantID; // lay du lieu ma ng dung da muon trade
        private List<Product> _products;

        public Customer Buyer
        {
            get => _buyer;
            set
            {
                _buyer = value;
                OnPropertyChanged();
            }
        }

        public List<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public SelectTradeProductWindow(Customer customer)
        {
            InitializeComponent();
            DataContext = this;
            InitializeAsync(customer.CustomerId);
            createUserHaveOnly = true;


        }

        public SelectTradeProductWindow(Customer customer,int userWantID)
        {
            InitializeComponent();
            DataContext = this;
            InitializeAsync(customer.CustomerId);
            _userWantID = userWantID;
           

        }

        private async void InitializeAsync(int buyerId)
        {
  
            var result = await _productBusiness.FindAvaliableProductList(buyerId);
            if (result?.Data is not null)
            {
                Products = (List<Product>)result.Data;
                ProductListGrid.ItemsSource = Products;
            }
            else
            {
                Products = new List<Product>();
            }

            SetBuyer(buyerId);
            var view = (CollectionView)CollectionViewSource.GetDefaultView(ProductListGrid.ItemsSource);
            view.Filter = UserFilter;
        }

        private async void SetBuyer(int buyerId)
        {
            var result = await _customerBusiness.GetById(buyerId);
            this.Buyer = (Customer)result.Data;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                var product = button.Tag as Product;
                if (product == null) // check co ton tai hay ko
                {
                    MessageBox.Show("Không tìm thấy sản phẩm bạn chọn ", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (product.Quantity == 0) // check thử product có số lượng lớn hơn 0 để trao đổi không
                {
                    MessageBox.Show($"sản phẩm không có số lượng để trao đổi: {product.Quantity} số lượng", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                 int productId = product.ProductId;
                 wUserHave wUserHave = new wUserHave(_buyer, productId, _userWantID); // truyen qua screen ng dung co cai gi de trade
                wUserHave.Show();
                  this.Hide();

      

            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Product).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ProductListGrid.ItemsSource).Refresh();
          
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}