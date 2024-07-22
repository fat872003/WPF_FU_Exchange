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
    /// Interaction logic for wPostProduct.xaml
    /// </summary>
    /// 
    //=================================== An
    public partial class wPostProduct : Window
    {
        public wPostProduct()
        {
            InitializeComponent();
        }

        private Customer _loggedInCustomer;
        private readonly ProductsBusiness productBusiness = new ProductsBusiness();
        private readonly UserHaveBusiness userHaveBusiness = new UserHaveBusiness();
        private readonly UserWantBusiness userWantBusiness = new UserWantBusiness();
        public wPostProduct(Customer customer)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            this.PostProduct_Loaded();
        }
        private async void PostProduct_Loaded()
        {


            var result = await productBusiness.getAllMyProduct(_loggedInCustomer.CustomerId);

            if (result.Status > 0 && result.Data != null)
            {
                dgvBookList.ItemsSource = result.Data as List<Product>;
            }
            else
            {
                dgvBookList.ItemsSource = new List<Product>();
            }
            // Thực hiện các thao tác cần thiết để tải lại dữ liệu trong cửa sổ
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {



            int quantityPostInt;
            if (!int.TryParse(txtQuantityPost.Text, out quantityPostInt))
            {
                MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu số lượng", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (quantityPostInt < 0)
            {
                MessageBox.Show("vui lòng nhập số lượng >0", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtNameProductPost.Text) || string.IsNullOrEmpty(txtQuantityPost.Text))
            {
                MessageBox.Show("Please enter full Information", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
    
            try
            {
                var newMyProduct = new Product()
                {
                    CustomerId = _loggedInCustomer.CustomerId,
                    Name = txtNameProductPost.Text,
                    Description = txtDesPost.Text,
                    Variation = txtVariation.Text,
                    Price = 0,
                    Quantity = quantityPostInt,
                    Origin = "FU_Exchange",
                    Img = (string.IsNullOrEmpty(txtImg.Text) ? null : txtImg.Text),
                    Status = true
                };



                var prodductResult = await productBusiness.CreateProduct(newMyProduct);

                if (prodductResult.Data!=null)
                {

                 MessageBox.Show("Tạo thành công", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                   
                }
                else
                {
                    MessageBox.Show("Tạo sản phẩm thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally {
                this.PostProduct_Loaded();
            }

        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


     
     


        private void txtShowAll_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = String.Empty;
            this.PostProduct_Loaded();
        } // xong r ne

        private async void btn_Avaliable_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                var resultEmptyName = await productBusiness.FindAvaliableProductList(_loggedInCustomer.CustomerId);

                dgvBookList.ItemsSource = resultEmptyName.Data as List<Product>;
                return;
            }
            var result = await productBusiness.FindAvaliableProductListByname(SearchTextBox.Text, _loggedInCustomer.CustomerId);

            dgvBookList.ItemsSource = result.Data as List<Product>;

        }

        //======================================== 
        private void update() {
            txtBookManager.Content = "Update your product";
            txtBookManager.Width += 66;
            btnCreate.Click -= btnCreate_Click;
            btnCreate.Click += btnUpdate_Click;
            btnCreate.Content = "Udpate";
            btnCreate.Background = Brushes.Yellow;
            btnCreate.Foreground = Brushes.Red;
            btnCreate.Width += 20;
            btnExit.Click -= btnExit_Click;
            btnExit.Click += btnCancel_Click;
            btnExit.Content = "Cancel";

        }


        //==========================================


        private async void btn_select(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có thể cập thông tin sản phẩm", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
            Button btn = sender as Button;
          
            if (int.TryParse(btn.CommandParameter.ToString(), out int productIDInt))
            {
                var product = await productBusiness.findProductById(productIDInt);

                if (product.Status > 0 && product.Data != null)
                {
                    update(); // goi ham sua lai layout update
                    var item = product.Data as Product;
                    // input lieu len ne
                    txtNameProductPost.Text = item.Name;
                    txtQuantityPost.Text = item.Quantity.ToString();
                    txtImg.Text = item.Img;
                    txtVariation.Text = item.Variation;
                    txtDesPost.Text = item.Description;
                    txtPostProductID.Text = item.ProductId.ToString();
                    this.PostProduct_Loaded();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Bạn có chắc chắn hủy cập nhật thông tin sản phẩm ?", "Cập nhật sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (result == MessageBoxResult.Yes)
            {
                resetScreenPostWindown();
            }



        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int quantityPostInt;
            if (!int.TryParse(txtQuantityPost.Text, out quantityPostInt))
            {
                MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu số lượng", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            if (quantityPostInt <0)
            {
                MessageBox.Show("vui lòng nhập số lượng >=0 ", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrEmpty(txtNameProductPost.Text) || string.IsNullOrEmpty(txtQuantityPost.Text))
            {
                MessageBox.Show("Vui lòng điển đầy đủ thông tin", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool statusPost = true;
            if (quantityPostInt == 0)
            {

                var statusCheck = MessageBox.Show("số lượng = 0 nghĩa là sản phẩm không khả dụng", "Input Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (statusCheck == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    statusPost = false;
                }
            }

            try
            {
               
                if (!int.TryParse(txtPostProductID.Text, out int postProductIdInt))
                {
                    MessageBox.Show("không tìm thấy ID sản phẩm", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var productIsExist = await productBusiness.findProductById(postProductIdInt);
                var updatedProduct = productIsExist.Data as Product;
                updatedProduct.Name = txtNameProductPost.Text;
                updatedProduct.Quantity = quantityPostInt;
                updatedProduct.Img = txtImg.Text;
                updatedProduct.Variation = txtVariation.Text;
                updatedProduct.Description = txtDesPost.Text;
                updatedProduct.Status = statusPost;
                var result = MessageBox.Show("Bạn có chắc chắn cập thông tin sản phẩm ?", "Cập nhật sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (result == MessageBoxResult.No)
                {
                    return;
                }
                var saveChangedUpdateProduct = await productBusiness.UpdateAproduct(updatedProduct);

                if (saveChangedUpdateProduct.Data !=null)
                {
                    MessageBox.Show("sản phẩm cập nhật thành công", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                }
                else
                {
                    MessageBox.Show("sản phẩm cập nhật thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                resetScreenPostWindown();
            }
        }



        // luc click dupate san pham bi status false ma no van 
        private async void btn_delete(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var result = MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm ?", "Cập nhật sản phẩm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            if (int.TryParse(btn.CommandParameter.ToString(), out int producID))
            {
                try
                {
                    var product = (await productBusiness.findProductById(producID)).Data as Product;
                    product.Status = false;

                    // status false vào những cái user have hoặc want liên quan đến product đang xóa này
                    var userHaveList = (await userHaveBusiness.findallHaveProductByProductId(product.ProductId)).Data as List<UserHave>;
                    foreach (UserHave userHave in userHaveList) { 
                        userHave.Status = false;
                        var removeUserHave = await userHaveBusiness.UpdateMyHaveProduct(userHave);
                        if (removeUserHave.Status != Const.SUCCESS_UPDATE_CODE) { 
                        MessageBox.Show("Đã xóa bên người dùng có lỗi!!", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                    }

                    var userWantList = (await userWantBusiness.getAllUserWantListByProductID(product.ProductId)).Data as List<UserWant>;
                    foreach (UserWant userWant in userWantList)
                    {
                        userWant.Status = false;
                        var removeUserWant = await userWantBusiness.UpdateUserWant(userWant);
                        if (removeUserWant.Status != Const.SUCCESS_UPDATE_CODE)
                        {
                            MessageBox.Show("Đã xóa bên người dùng có lỗi!!", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                    }



                    var removeProduct = await productBusiness.UpdateAproduct(product);
                    if (removeProduct.Data !=null )
                    {
                        MessageBox.Show("Đã xóa sản phẩm thành công!!", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã xóa sản phẩm không thành công!!", "Cập nhật sản phẩm", MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                finally
                {
                    this.PostProduct_Loaded() ;
                }

            }


        }


        public void resetScreenPostWindown()
        {

            this.PostProduct_Loaded();
            txtNameProductPost.Text = string.Empty;
            txtQuantityPost.Text = string.Empty;
            txtImg.Text = string.Empty;
            txtVariation.Text = string.Empty;
            txtDesPost.Text = string.Empty;
            txtPostProductID.Text = string.Empty;
            btnCreate.Click -= btnUpdate_Click;
            btnCreate.Click += btnCreate_Click;
            btnCreate.Content = "Create";
            btnCreate.Width -= 20;
            btnExit.Click -= btnCancel_Click;
            btnExit.Click += btnExit_Click;
            btnExit.Content = "Exit";
            txtBookManager.Content = "Post Product";
            txtBookManager.Width -= 66;
        }


       
  

        private async void txtProductNameSreach_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))

            {
                this.PostProduct_Loaded();
                return;
            }

            var result = await productBusiness.FindProductsListByName(searchText, _loggedInCustomer.CustomerId);
            dgvBookList.ItemsSource = result.Data as List<Product>; 
        }

        private async void PostProduct_Loaded(object sender, RoutedEventArgs e)
        {
            this.PostProduct_Loaded();

        }

        
        // lam o day ne
        private void btn_detail(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (int.TryParse(button.CommandParameter.ToString(), out int producID)) {
                ProductWindow productWindow = new ProductWindow(producID);
                productWindow.Show();
            }
          
        }

        private void btn_trade(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (int.TryParse(button.CommandParameter.ToString(), out int producID))
            {
                wUserHave wUserHaveScreen = new wUserHave(_loggedInCustomer,producID);
                wUserHaveScreen.Show();
            }
        }
    }
}
