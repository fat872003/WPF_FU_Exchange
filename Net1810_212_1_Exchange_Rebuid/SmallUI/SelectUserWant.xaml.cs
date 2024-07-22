using Exchange.Business;
using Exchange.Data.Models;
using Exchange.WpfApp.UI;
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

namespace Exchange.WpfApp.SmallUI
{
    /// <summary>
    /// Interaction logic for SelectUserWant.xaml
    /// </summary>
    public partial class SelectUserWant : Window
    {
        private readonly UserWantBusiness _business = new UserWantBusiness();


        private  Customer _loggedInCustomer;
        private int _userHaveID = 0;
        private  int _orderID = 0;
        public SelectUserWant()
        {
            InitializeComponent();
            this.Product_Loaded();
        }

        public SelectUserWant(Customer customer)
        {
            _loggedInCustomer = customer;
           
            InitializeComponent();
            this.Product_Loaded();

        }


        public SelectUserWant(Customer customer, int userHaveID)
        {
            _loggedInCustomer = customer;
            _userHaveID = userHaveID;
            InitializeComponent();
            this.Product_Loaded();

        }
        public SelectUserWant(Customer customer, int userHaveID, int orderID)
        {
            _loggedInCustomer = customer;
            _userHaveID = userHaveID;
            _orderID = orderID;
            InitializeComponent();
            this.Product_Loaded();

        }
        private async void Product_Loaded()
        {
            var userHaveProduct = await _business.getinforUserWantList(_loggedInCustomer.CustomerId);

            if (userHaveProduct.Status > 0 && userHaveProduct.Data != null)
            {
                grdProduct.ItemsSource = userHaveProduct.Data as List<UserWant>;
            }
            else
            {
                grdProduct.ItemsSource = new List<UserWant>();
            }
        }


        private async void Product_Loaded(object sender, RoutedEventArgs e)
        {
            this.Product_Loaded();
        }
        public async void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
           

            Button btn = (Button)sender;
            var result = MessageBox.Show("Đây là thông tin về trao đổi của bạn", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);

            if (int.TryParse(btn.CommandParameter.ToString(), out int userWantID))
            {


                var userWant = (await _business.findMyWantProductById(userWantID)).Data as UserWant;

                if (userWant != null)
                {
                    if (userWant.Status==false) {
                        MessageBox.Show("Vui lòng chọn sản phẩm muốn trao đổi khả dụng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                    txt_userWantID.Text = userWantID.ToString();
                    ProductName.Text = userWant.Product.Name.ToString();
                    txtQuantity.Text = userWant.Quantity.ToString();
                    txtDes.Text = userWant.Description.ToString();
                    txtNote.Text = userWant.Note.ToString();
                    txtCreateDate.Text = userWant.CreateDate.ToString();
                }
            }
        }




        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))

            {
                Product_Loaded();
                return;
            }

            var result = await _business.getinforUserWantListByDes(_loggedInCustomer.CustomerId, searchText);
            grdProduct.ItemsSource = result.Data as List<UserWant>;
        }

        private async void ButtonSumbit_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txt_userWantID.Text, out int txt_userWantIDInt))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
   
            wMyOder myOder;
            if (_orderID==0) {
                if (_userHaveID != 0)
                {
                    myOder = new wMyOder(_loggedInCustomer, txt_userWantIDInt, _userHaveID);
                }
                else {
                    myOder = new wMyOder(_loggedInCustomer);
                    myOder.getInforuserWant(txt_userWantIDInt);
                }
            
            }
            else {
                myOder = new wMyOder(_loggedInCustomer, txt_userWantIDInt, _userHaveID, _orderID);
            }
            this.Hide();
            myOder.Show();


        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
