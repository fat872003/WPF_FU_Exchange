using Exchange.Business;
using Exchange.Common;
using Exchange.Data.Models;
using Exchange.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Exchange.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wProduct.xaml
    /// </summary>
    public partial class wProduct : Window
    {

        private readonly UserHaveBusiness _business =   new UserHaveBusiness();
        private readonly Customer _loggedInCustomer;
        public wProduct()
        {
           
            InitializeComponent();
    
            Loaded += Product_Loaded;
        }
        public wProduct(Customer customer)
        {
            _loggedInCustomer = customer;
            InitializeComponent();
            Loaded += Product_Loaded;
        }



        private async void Product_Loaded(object sender, RoutedEventArgs e) // lấy dữ liệu tát cả sản phẩm của ng dugf khác muốn trao đổi 
        {
            var userHaveProduct = await _business.GetAllProductHomePage(_loggedInCustomer.CustomerId);

            if (userHaveProduct != null)
            {
                grdProduct.ItemsSource = userHaveProduct.Data as List<UserHave>;
            }
            else
            {
                MessageBox.Show($"khong thay ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }


        private void ButtonTrade_Click(object sender, RoutedEventArgs e) // nhấn nút traod dổi sẽ qua màn hình khác nhau
        {
            var btn = sender as Button;
            if (int.TryParse(btn.CommandParameter.ToString(), out int ProductUserHaveId))
            {
                ProductWindow productWindow = new ProductWindow(ProductUserHaveId, _loggedInCustomer); // truyền tham số cái sản phẩm mà ng dùng muốn trade qua screen khác
                productWindow.Show();   

            }
        }

       

     

      

        

        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(searchText))

            {
                var allProducts = await _business.GetAllProductHomePage(_loggedInCustomer.CustomerId);
                grdProduct.ItemsSource = allProducts.Data as List<UserHave>;
            }
            else
            {

                var result = await _business.SearchByName(searchText, _loggedInCustomer.CustomerId);


                if (result.Status > 0 && result.Data != null)
                {
                    grdProduct.ItemsSource = result.Data as List<UserHave>;
                }
                else
                {
                    grdProduct.ItemsSource = new List<UserHave>();
                }
            }
        }

        private void Open_PostProduct_Click(object sender, RoutedEventArgs e)
        {
            var p = new wPostProduct(_loggedInCustomer);
            p.Owner = this;
            p.Show();

        }

        private void Open_UserHave_Click(object sender, RoutedEventArgs e)
        {
            var x = new wUserHave(_loggedInCustomer);
            x.Owner = this;
            x.Show();

        }

        private void Open_UserWant_Click(object sender, RoutedEventArgs e)
        {
            var x = new wUserWant(_loggedInCustomer);
            x.Owner = this;
            x.Show();
        }

        private void Open_OrderDetail_Click(object sender, RoutedEventArgs e)
        {
            var x = new wMyOder(_loggedInCustomer);
            x.Owner = this;
            x.Show();
        }

        private void Open_WishList_Click(object sender, RoutedEventArgs e)
        {
            var x = new wWishList(_loggedInCustomer);
            x.Owner = this;
            x.Show();
        }

        private void Open_order_Click(object sender, RoutedEventArgs e)
        {

            var x = new wOrder(_loggedInCustomer);
            x.Owner = this;
            x.Show();

        }
    }
}
