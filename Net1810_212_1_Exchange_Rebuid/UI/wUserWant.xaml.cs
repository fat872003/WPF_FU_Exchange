using Exchange.Business;
using Exchange.Common;
using Exchange.Data.Models;
using Microsoft.IdentityModel.Tokens;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Exchange.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wUserWant.xaml
    /// </summary>
    public partial class wUserWant : Window
    {

        private Customer _loggedInCustomer;
        private UserWantBusiness userWantBusiness = new UserWantBusiness();
        private UserHaveBusiness userHaveBusiness = new UserHaveBusiness();
        private OrderBusiness orderBusiness = new OrderBusiness();
        private OrderDetailBusiness orderDetailBusiness = new OrderDetailBusiness();
        private ProductsBusiness productsBusiness = new ProductsBusiness(); 
        private int newUserHaverIDisSelected;
        private UserWant UserWantProduct; // o day la san phan ma ng dung muon trao doi
        public wUserWant()
        {
            InitializeComponent();
        }

        public wUserWant(Customer customer)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
         
        }
        public wUserWant(Customer customer, int UserHaverIDisSelected) // tao xong thuc hien giao dich
        {
            InitializeComponent();

            _loggedInCustomer = customer;
            newUserHaverIDisSelected = UserHaverIDisSelected;
            getNewUserWantProduct(_loggedInCustomer, UserHaverIDisSelected);

            
            
        }




        private async void getNewUserWantProduct(Customer customer,int UserHaverIDisSelected)
        {
            var UserHave = (await userHaveBusiness.findMyHaveProductById(UserHaverIDisSelected)).Data as UserHave; // tim san pham ma ng ta dang len nhung that ra la use have cua ng hkac
            var product = await productsBusiness.findProductById(UserHave.ProductId);

            if (UserHave!=null) {
                var productData = product.Data as Product;
                txtUserWanttId.Text = UserHaverIDisSelected.ToString();
                txtUserWantName.Text = productData.Name;
                txtUserWantQuantity.Text = UserHave.Quantity.ToString(); // de mac dinh la max cua product
                txtUseWantPrice.Text = UserHave.Price.ToString();
                txtUserWantDescription.Text = UserHave.Description;
                txtGapPrice.Text = UserHave.GapPrice.ToString();
                txtcurrency.Text = UserHave.Currency.ToString();
                txtNote.Text = UserHave.Note.ToString();
                txtCreateDate.Text = UserHave.CreateDate.ToString();
                txtFax.Text = UserHave.Fax.ToString();
                txtStatus.Text = (UserHave.Status==true)?"1":"0";    
            }
        }




        private async void StackPanel_Loaded()
        {

           
            var result = await userWantBusiness.getinforUserWantList (_loggedInCustomer.CustomerId);        
           
            if (result.Status > 0 && result.Data != null)
            {
                grdUserWant.ItemsSource = result.Data as List<UserWant>;
            }
            else
            {
                grdUserWant.ItemsSource = new List<UserWant>();
            }
        }

        private void resetLayout() {
            txtUserWanttId.Text = string.Empty;
            txtUserWantName.Text = string.Empty;
            txtUserWantQuantity.Text = string.Empty; // de mac dinh la max cua product
            txtUseWantPrice.Text = string.Empty;
            txtUserWantDescription.Text = string.Empty;
            txtGapPrice.Text = string.Empty;
            txtcurrency.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtCreateDate.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtStatus.Text = string.Empty;  
            ButtonSave.Content = "save";
            ButtonSave.Click -= ButtonUpdate_Click;
            ButtonSave.Click += Buttonsave_Click;
            this.StackPanel_Loaded();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            resetLayout();
        }

        private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtUserWantQuantity.Text.Trim(), out int UserWantQuantity))
            {
                MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu số lượng", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           

            if (!int.TryParse(txtUserWanttId.Text, out int userWantID))
            {
                return;
            }
            if (UserWantQuantity <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng >0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            try
            {
                var userHave = await userWantBusiness.getinforUserWant(userWantID);
                if (userHave.Data as UserWant == null)
                {
                    MessageBox.Show("Không tìm thấy vật để update", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var userWantData = userHave.Data as UserWant;
                userWantData.Quantity = UserWantQuantity;
                userWantData.Description= txtUserWantDescription.Text;
                userWantData.Note = txtNote.Text;
                userWantData.CreateDate = DateTime.Now;
                userWantData.Status = (txtStatus.Text.Trim()=="0")?false:true;
               
                if (userWantData.Quantity > userWantData.Product.Quantity)
                {

                    MessageBox.Show($"Số lượng vượt quá giới hạn trong kho của bạn:{userWantData.Product.Quantity}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

             
                var result = MessageBox.Show("Bạn có chắc chắn lưu thông tin sản phẩm ?", "Cập nhật sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (result == MessageBoxResult.No)
                {
                    return;
                }
                var saveChangedUpdateProduct = await userWantBusiness.UpdateUserWant(userWantData);

                if (saveChangedUpdateProduct.Data != null)
                {
                    MessageBox.Show("Sản phẩm bạn muốn đã cập nhật thành công.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                  
                }
                else
                {
                    MessageBox.Show("Sản phẩm bạn muốn đã cập nhật thất bại.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                resetLayout();

            }



        }
      private void update() {

            ButtonSave.Content = "Update";
            ButtonSave.Click -= Buttonsave_Click;
            ButtonSave.Click += ButtonUpdate_Click;
        }
        private async void grdUserhave_ButtonSelect_Click(object sender, RoutedEventArgs e)
        {

            update();

            MessageBox.Show("Bạn có thể cập thông tin sản phẩm", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
            Button btn = sender as Button;
            if (!int.TryParse(btn.CommandParameter.ToString(), out int userWantID))
            {
                return;
            }

            var userWant = await userWantBusiness.getinforUserWant(userWantID);
            if (userWant != null)
            {
                var userWantData = userWant.Data as UserWant;
                txtUserWanttId.Text = userWantData.ProductId.ToString();
                txtUserWantName.Text = userWantData.Product.Name;
                txtUserWantQuantity.Text = userWantData.Quantity.ToString();
                txtUseWantPrice.Text = "0";
                txtUserWantDescription.Text = userWantData.Description;
                txtGapPrice.Text = "0";
                txtcurrency.Text = userWantData.Currency;
                txtNote.Text= userWantData.Note;
                txtCreateDate.Text = userWantData.CreateDate.ToString();
                txtFax.Text = "0";
                txtStatus.Text = (userWantData.Status == true) ? "1" : "0";

            }
        }

    
        private async void Buttonsave_Click(object sender, RoutedEventArgs e)
        {
            
            var UserHave = (await userHaveBusiness.findMyHaveProductById(newUserHaverIDisSelected)).Data as UserHave; // tim san pham ma ng ta dang len nhung that ra la use have cua ng hkac
            if (UserHave == null)
            {
                MessageBox.Show("vui lòng chọn sản phẩm trao đổi để lưu", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtUserWantQuantity.Text, out int UserHaveQuantityInt))
            {
                MessageBox.Show("vui lòng nhập đúng kiểu dữ liệu số lượng ", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (UserHaveQuantityInt > UserHave.Quantity) {
                MessageBox.Show($"Không đước nhập quá số lượng bài đăng: {UserHave.Quantity}", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            try {

                UserWant userWant = new UserWant()
                {
                    ProductId = UserHave.ProductId,
                    Description = UserHave.Description,
                    Price = UserHave.Price,
                    GapPrice = UserHave.GapPrice,
                    Fax = UserHave.Fax,
                    Note = UserHave.Note,
                    CreateDate = UserHave.CreateDate,
                    Currency = UserHave.Currency,
                    Quantity = UserHaveQuantityInt,
                    Status = true
                };

                if (userWant == null)
                {
                    MessageBox.Show("Không tạo được sản phẩm trao đổi!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var result = await userWantBusiness.addNewUSerWant(userWant);

                if (result.Data ==null)
                {
                    MessageBox.Show("Lưu không thành công!!!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                   

                }
                else
                {
                     var asking =  MessageBox.Show("Lưu thành công!!!\n Bạn có muốn tiếp tục thực hiện giao dịch không?", "Input Error", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (asking == MessageBoxResult.Yes) {
                        ButtonSave.Click -= Buttonsave_Click;
                        ButtonSave.Click += ButtonContinue_Click;
                        ButtonSave.Content = "Continue";
                        ButtonSave.Width += 20;
                    }
                }
                

            }
            catch (Exception ex) {
                MessageBox.Show($"{ex.Message}", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                StackPanel_Loaded();
            }
                
        }

        private async void ButtonContinue_Click(object sender, RoutedEventArgs e) {
            SelectTradeProductWindow selectTradeProductWindow = new SelectTradeProductWindow(_loggedInCustomer, newUserHaverIDisSelected);
            selectTradeProductWindow.Show();
            this.Close();
        }







        private async void grdUserhave_ButtonDelete_Click(object sender, RoutedEventArgs e) // chua lam ne
        {

            Button btn = sender as Button;
            if (!int.TryParse(btn.CommandParameter.ToString(), out int userWantID))
            {
                return;
            }

            try
            {
                var userWant = (await userWantBusiness.getinforUserWant(userWantID)).Data as UserWant;

                if (userWant == null)
                {
                    MessageBox.Show("khong tahy item", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                userWant.Status = false;
                var result = await userWantBusiness.UpdateUserWant(userWant);
                if (result.Data != null)
                {
                    MessageBox.Show("Xóa vật phẩm thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Xóa vật phẩm thất bại", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally { 
                StackPanel_Loaded();


            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel_Loaded();
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))

            {
                this.StackPanel_Loaded();
                return;
            }

            var result = await userWantBusiness.getinforUserWantListByDes(_loggedInCustomer.CustomerId, searchText);
            grdUserWant.ItemsSource = result.Data as List<UserWant>;
        }
    }
}
