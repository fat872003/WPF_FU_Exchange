using Exchange.Business;
using Exchange.Common;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;

namespace Exchange.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wUserHave.xaml
    /// </summary>
    public partial class wUserHave : Window
    {


        private Customer _loggedInCustomer;
        private UserHaveBusiness userHaveBusiness = new UserHaveBusiness();
        private OrderBusiness orderBusiness = new OrderBusiness();
        private OrderDetailBusiness orderDetailBusiness = new OrderDetailBusiness();
        private ProductsBusiness productsBusiness = new ProductsBusiness();
        private int _userWantID;
        private int _userHaveID;
        private int newProductID;

        //================================= An
        public wUserHave()
        {
            InitializeComponent();
            this.StackPanel_Loaded();
        }

        public wUserHave(Customer customer)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            this.StackPanel_Loaded();
        }


        public wUserHave(Customer customer,int productID)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            newProductID=productID;

            addNewUserHaveItem(newProductID);
           
        }

        public wUserHave(Customer customer, int productID,int userWantID) // phễu này là hứng giá trị bên user want và qua đay tạo usewant mới đc chọn
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            newProductID = productID;

            _userWantID = userWantID;   
            addNewUserHaveItem(newProductID);
        }
        private async void StackPanel_Loaded()
        {
            // vi ko nhat the oder moi dung have nen t t co the tao bat ki luc nao cung dc
            var result = await userHaveBusiness.getMyHaveProductList(_loggedInCustomer.CustomerId);

            if (result.Status > 0 && result.Data != null)
            {
                grdUserHave.ItemsSource = result.Data as List<UserHave>;
            }
            else
            {
                grdUserHave.ItemsSource = new List<UserHave>();
            }
        }
        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            this.StackPanel_Loaded();
        }


        private async void addNewUserHaveItem(int newProductID) {

            var product = (await productsBusiness.findProductById(newProductID)).Data as Product;

            txtUserHaveName.Text = product.Name;
            txtProductId.Text = product.ProductId.ToString();
            txtUserHaveQuantity.Text = product.Quantity.ToString();

            txtUserWantDescription.Text = "Empty";
            txtGapPrice.Text = "0";
            txtcurrency.Text = "VND";
            txtNote.Text = "Tôi muốn trao đổi sản phẩm này ";
            txtCreateDate.Text = DateTime.Now.ToString();
            txtFax.Text = "0";
            txtStatus.Text = (product.Status==true)?"1":"0";
            this.StackPanel_Loaded();
        }


        private void resetLayout()
        {
            ButtonSave.Content = "save";
            ButtonSave.Click -= ButtonUpdate_Click;
            ButtonSave.Click += ButtonSave_Click;
          


            txtUserHaveName.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtUserHaveQuantity.Text = string.Empty;

            txtUserWantDescription.Text = string.Empty;
            txtGapPrice.Text = string.Empty;
            txtcurrency.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtCreateDate.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtStatus.Text = string.Empty;
            this.StackPanel_Loaded();
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductId.Text)) {
                MessageBox.Show("để lưu bạn phải chọn sản phẩm bạn có", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                SelectTradeProductWindow selectTradeProductWindow = new SelectTradeProductWindow(_loggedInCustomer);
                selectTradeProductWindow.Show();
                this.Close();    
;                return;
            }

            try
            {
                if (!int.TryParse(txtUserHaveQuantity.Text.Trim(), out int UserHaveQuantity) || UserHaveQuantity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu số lượng", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!int.TryParse(txtProductId.Text, out int ProductId))
                {
                    MessageBox.Show("lỗi ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                if (txtStatus.Text=="0")
                {
                    MessageBox.Show("Bên không khả dụng không trao đổi được vui lòng chọn sản phẩm khác", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var product = (await productsBusiness.findProductById(ProductId)).Data as Product;
                if (product == null)
                {
                    MessageBox.Show("không tìm thấy product", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                if (UserHaveQuantity > product.Quantity)
                {
                    MessageBox.Show($"Không được nhập quá số luọng kho: {product.Quantity}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                UserHave newUserHave = new UserHave()
                {
                    ProductId = ProductId,
                    Description = txtUserWantDescription.Text,
                    Price = 0,
                    GapPrice=0,
                    Fax = 0,
                    Note = txtNote.Text,
                    CreateDate = DateTime.Now,
                    Currency = "VND",
                    Quantity = UserHaveQuantity,
                    Status=true
                };

                var inserUserHave = await userHaveBusiness.saveMyHaveProduct(newUserHave);

                if (inserUserHave.Status > 0)
                {
                    MessageBox.Show("thành công nhập ", "thông tin", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.StackPanel_Loaded();
                    if (_userWantID >0) { // này tránh tr hợp muốn tạo xong thục hiện tiếp giao dịch
                        var result = MessageBox.Show("Bạn có muốn tiếp tục trao đổi nữa không?", "Thành công", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        if (result == MessageBoxResult.Yes)
                        {
                            _userHaveID = newUserHave.ProductUserHaveId;
                            ButtonSave.Click -= ButtonSave_Click;
                            ButtonSave.Click += Buttoncontinue_Click;
                            ButtonSave.Content = "continue";
                            return;
                        }
                        resetLayout();

                    }
                   

                }
                else
                {
                    MessageBox.Show("khôgn thành công nhập", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
          


        }
        private void Buttoncontinue_Click(object sender, RoutedEventArgs e)
        {
            wMyOder wMyOder = new wMyOder(_loggedInCustomer, _userWantID,_userHaveID);    
            wMyOder.Show();
            this.Close();
        }


        private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)

        {

            if (!int.TryParse(txtUserHaveQuantity.Text.Trim(), out int UserHaveQuantity))
            {
                MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu số lượng", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
         

            if (!int.TryParse(txtUserHaveID.Text, out int userHaveID))
            {
                return;
            }
            if(UserHaveQuantity<=0)
            {
                MessageBox.Show("Vui lòng nhập số lượng >0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var userHave = await userHaveBusiness.getMyHaveProduct(userHaveID);
                if (userHave.Data as UserHave == null)
                {
                    MessageBox.Show("Không tìm thấy vật để update", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (txtStatus.Text=="1".Trim()) { 
                    var product = (await productsBusiness.findProductById((userHave.Data as UserHave).ProductId)).Data as Product;
                    if (product.Status==false) {
                        MessageBox.Show("Sản phẩm bên kho đang không hkả dụng nên không thể thay đổi được", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                var userHaveData = userHave.Data as UserHave;
                userHaveData.Quantity = UserHaveQuantity;
                userHaveData.Description = txtUserWantDescription.Text;
                userHaveData.Note=txtNote.Text;
                userHaveData.Status = (txtStatus.Text.Trim()=="0")?false : true; 
                userHaveData.CreateDate = DateTime.Now; 
                if (userHaveData.Quantity > userHaveData.Product.Quantity)
                {

                    MessageBox.Show("Số lượng vượt quá giới hạn trong kho của bạn", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

          
                var result = MessageBox.Show("Bạn có chắc chắn lưu thông tin sản phẩm ?", "Cập nhật sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (result == MessageBoxResult.No)
                {
                    return;
                }
                var saveChangedUpdateProduct = await userHaveBusiness.UpdateMyHaveProduct(userHaveData);

                if (saveChangedUpdateProduct.Status == Const.SUCCESS_UPDATE_CODE)
                {
                    MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                  
                }
                else
                {
                    MessageBox.Show("cập nhật thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }finally {
                resetLayout();
            }


        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
         resetLayout();
        }

        private async void grdUserhave_ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            ButtonSave.Content = "Update";
            ButtonSave.Click -= ButtonSave_Click;
            ButtonSave.Click += ButtonUpdate_Click;
            
          
           
            MessageBox.Show("Bạn có thể cập thông tin sản phẩm", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
            Button btn = sender as Button;
            if (!int.TryParse(btn.CommandParameter.ToString(), out int userHaveID)) {
                return;
            }

            var userHave = await userHaveBusiness.getMyHaveProduct(userHaveID);
            if (userHave != null) {
                var userHaveData = userHave.Data as UserHave;
                txtUserHaveID.Text = userHaveData.ProductUserHaveId.ToString();
                txtUserHaveName.Text = userHaveData.Product.Name;
                txtUserHaveQuantity.Text = userHaveData.Quantity.ToString();
                txtUseWantPrice.Text = userHaveData.Price.ToString();
                txtUserWantDescription.Text = userHaveData.Description.ToString();
                txtGapPrice.Text = userHaveData.GapPrice.ToString();
                txtcurrency.Text= userHaveData.Currency.ToString();
                txtNote.Text = userHaveData.Note.ToString();
                txtCreateDate.Text = userHaveData.CreateDate.ToString();
                txtFax.Text = userHaveData.Fax.ToString();  
                txtProductId.Text = userHaveID.ToString();
                txtStatus.Text = (userHaveData.Status==true)?"1":"0";
            }
        }

        private async void grdUserhave_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (!int.TryParse(btn.CommandParameter.ToString(), out int userHaveID))
            {
                return;
            }

            var userHave = (await userHaveBusiness.getMyHaveProduct(userHaveID)).Data as UserHave;
            if (userHave ==null) { 
            MessageBox.Show("Không tìm sản phẩm để xóa!!", "lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            userHave.Status = false;
            var result = await userHaveBusiness.UpdateMyHaveProduct(userHave);
            if (result.Data !=null) { 
            MessageBox.Show("Xóa thành công!!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                MessageBox.Show("Xóa thất bại!!", "lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            this.StackPanel_Loaded();

        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))

            {
                this.StackPanel_Loaded();
                return;
            }

            var result = await userHaveBusiness.SearchByDesAndNoteMyUserHaveList(searchText, _loggedInCustomer.CustomerId);
            grdUserHave.ItemsSource = result.Data as List<UserHave>;

        }
    }
}
