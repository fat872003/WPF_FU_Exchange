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
    /// Interaction logic for SelectUserHave.xaml
    /// </summary>
    public partial class SelectUserHave : Window
    {
        private readonly UserHaveBusiness _business = new UserHaveBusiness();

        private readonly Customer _loggedInCustomer;
        private  int _userWantID = 0;
        private int _orderID = 0;
     
        public SelectUserHave(Customer customer)
        {
          
          
            InitializeComponent();
            _loggedInCustomer = customer;
            this.Product_Loaded();

        }
        public SelectUserHave(Customer customer, int userWantID)
        {
          
            InitializeComponent();
            _loggedInCustomer = customer;
            _userWantID = userWantID;
            this.Product_Loaded();

        }

        public SelectUserHave(Customer customer, int userWantID, int orderID)
        {
            _loggedInCustomer = customer;
            _userWantID = userWantID;   
            _orderID = orderID;
            InitializeComponent();
            this.Product_Loaded();

        }
        private async void Product_Loaded()
        {
            var userHaveProduct = await _business.getMyHaveProductList(_loggedInCustomer.CustomerId);

            if ( userHaveProduct.Data == null)
            {
            grdProduct.ItemsSource =new List<UserHave>();

                return;
            }
            grdProduct.ItemsSource = userHaveProduct.Data as List<UserHave>;

        }
        private async void Product_Loaded(object sender, RoutedEventArgs e)
        {
           this.Product_Loaded();
        }
        public async void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
           

            Button btn = (Button)sender;
             MessageBox.Show("Đây là thông tin về trao đổi của bạn", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);

            if (int.TryParse(btn.CommandParameter.ToString(), out int userHaveID))
            {


                var userHaveData = (await _business.getinforUserHave(userHaveID)).Data as UserHave;
           
                if (userHaveData != null)
                {
                    if (userHaveData.Status==false) {
                        MessageBox.Show("Vui lòng chọn sản phẩm trao đổi khả dụng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                   /* txt_userHaveID.Text = userHaveID.ToString();
                    ProductName.Text = userHaveData.Product.Name.ToString();
                    txtQuantity.Text = userHaveData.Quantity.ToString();
                    txtDes.Text = userHaveData.Description.ToString();
                    txtNote.Text = userHaveData.Note.ToString();    
                    txtCreateDate.Text = userHaveData.CreateDate.ToString();  */  
                }
            }
        }

    

        
        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        /*    string searchText = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(searchText))

            {
                var userHaveProduct = await _business.getMyHaveProductList(_loggedInCustomer.CustomerId);

                grdProduct.ItemsSource = userHaveProduct.Data as List<UserHave>;
            }
            else
            {

                var result = await _business.SearchByDesAndNoteMyUserHaveList(searchText, _loggedInCustomer.CustomerId);  


                if (result.Status > 0 && result.Data != null)
                {
                    grdProduct.ItemsSource = result.Data as List<UserHave>;
                }
                else
                {
                    grdProduct.ItemsSource = new List<UserHave>();
                }
            }*/
        }

        private async void ButtonSumbit_Click(object sender, RoutedEventArgs e)
        {
         /*   if (!int.TryParse(txt_userHaveID.Text, out int txt_userHaveIDInt))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            wMyOder myOder;
            if (_orderID == 0)
            {
                if (_userWantID != 0)
                {
                    myOder = new wMyOder(_loggedInCustomer, _userWantID, txt_userHaveIDInt);
                }
                else
                {

                    myOder = new wMyOder(_loggedInCustomer);
                    myOder.getInforuserHave(txt_userHaveIDInt);
                }

            }
            else
            {
                myOder = new wMyOder(_loggedInCustomer, _userWantID, txt_userHaveIDInt, _orderID);
            }*/
            this.Hide();
            ///**/myOder.Show();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Product_Loaded();
        }
    }
}
