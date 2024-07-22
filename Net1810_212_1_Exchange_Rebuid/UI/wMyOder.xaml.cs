using Exchange.Business;
using Exchange.Common;
using Exchange.Data.Models;
using Exchange.WpfApp.SmallUI;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace Exchange.WpfApp.UI
{
   
    public partial class wMyOder : Window
    {
        private   Customer _loggedInCustomer;
        private  int _userWantID = 0;
        private  int _userHaveID = 0;
        private  int _orderDetailID = 0;
        private OrderBusiness _orderBusiness = new OrderBusiness();
        private OrderDetailBusiness _orderDetailBusiness = new OrderDetailBusiness();
        private ProductsBusiness _productsBusiness = new ProductsBusiness();
        private UserHaveBusiness _userHaveBusiness = new UserHaveBusiness();
        private UserWantBusiness _userWantBusiness = new UserWantBusiness();


        public wMyOder()
        {
            InitializeComponent();
        }

        public wMyOder(Customer customer)
        {
            InitializeComponent();
          
            _loggedInCustomer = customer;
         

        }
        public wMyOder(Customer customer, int userWantID, int userHaveID)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            _userWantID = userWantID;
            _userHaveID = userHaveID;
            yourTradeInformation(userWantID, userHaveID, _orderDetailID);
           
        }


        public wMyOder(Customer customer, int userWantID, int userHaveID,int orderDetailID)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            _userWantID = userWantID;
            _userHaveID = userHaveID;
            _orderDetailID = orderDetailID;
             update();           
            yourTradeInformation(userWantID, userHaveID, _orderDetailID);
           
           
        }
        //=============================== menu
        private void Open_UserHave_Click(object sender, RoutedEventArgs e)
        {
            var x = new wUserHave(_loggedInCustomer);
            x.Owner = this;
            x.Show();
        }

        private void Open_PostProduct_Click(object sender, RoutedEventArgs e)
        {

            var p = new wPostProduct(_loggedInCustomer);
            p.Owner = this;
            p.Show();
        }

        //=================================

        public async void getInforuserHave(int userHaveID) {
            _userHaveID = userHaveID;
            var myHaveProduct = (await _userHaveBusiness.getinforUserHave(userHaveID)).Data as UserHave;
            txt_haveProductName.Text = myHaveProduct.Product.Name;
            txt_havequantityProduct.Text = myHaveProduct.Quantity.ToString();
            txt_createCustommer.Text = myHaveProduct.Product.Customer.FullName;
            this.Window_Loaded();
        }
        public async void getInforuserWant(int userWantID)
        {
            _userWantID = userWantID;
            var myWantProduct = (await _userWantBusiness.getinforUserWant(userWantID)).Data as UserWant;
            txt_wantProductName.Text = myWantProduct.Product.Name;
            txt_wantQuantityProduct.Text = myWantProduct.Quantity.ToString();
            this.Window_Loaded();
        }

        private async void yourTradeInformation(int userWantID, int userHaveID,int orderDetailID) {         
            var myHaveProduct = (await _userHaveBusiness.getinforUserHave(userHaveID)).Data as UserHave;
            var myWantProduct = (await _userWantBusiness.getinforUserWant(userWantID)).Data as UserWant;           
            txt_haveProductName.Text = myHaveProduct.Product.Name ;
            txt_havequantityProduct.Text = myHaveProduct.Quantity.ToString();
            txt_wantProductName.Text = myWantProduct.Product.Name;
            txt_wantQuantityProduct.Text = myWantProduct.Quantity.ToString();
            txt_orderDetailID.Text = (orderDetailID == 0) ? "Empty" : orderDetailID.ToString();
            if (orderDetailID != 0)
            {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;
                txt_Address.Text = orderDetail.Address;
                txt_Message.Text = orderDetail.Message;
                txt_Status.Text = (orderDetail.Status == true) ? "1" : "0";
            }
            else {
                txt_Address.Text = "Vui lòng nhập dịa chỉ";
                txt_Message.Text = "Tôi muốn trao đổi";
                txt_Status.Text = "1";
            }
            txt_createCustommer.Text = myHaveProduct.Product.Customer.FullName;
            
           
            this.Window_Loaded();
          
        }

        private void resetLayout() {
            txt_haveProductName.Text = string.Empty;
            txt_havequantityProduct.Text = string.Empty;
            txt_Message.Text = string.Empty;
            txt_wantProductName.Text = string.Empty;
            txt_wantQuantityProduct.Text = string.Empty;
            txt_Address.Text = string.Empty;
            txt_Status.Text = string.Empty;
            txt_createCustommer.Text = string.Empty;
            txt_orderDetailID.Text = string.Empty;
            ButtonSave.Click -= ButtonUpdate_Click;
            ButtonSave.Click += ButtonSave_Click;
            _userWantID = 0;
            _userHaveID = 0;
            _orderDetailID = 0;
            ButtonSave.Content = "save";
            ButtonSave.Width -= 20;
            this.Window_Loaded();

        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txt_haveProductName.Text)) { 
                MessageBox.Show("để lưu bạn phải chọn sản phẩm để giao dịch", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                  return;
            }
            if (string.IsNullOrEmpty(txt_wantProductName.Text)) {
                MessageBox.Show("để lưu bạn phải chọn sản phẩm muốn giao dịch", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try {
                OrderDetail orderDetail = new OrderDetail() {
                    ProductUserHaveId = _userHaveID,
                    ProductUserWantId = _userWantID,
                    GapPrice = 0,
                    Proposer = "Exchange Student Application",
                    Discount = 0,
                    Message = txt_Message.Text,
                    Address = txt_Address.Text,
                    Status = true
                };    
                var result = (await _orderDetailBusiness.saveOrderDetail(orderDetail)).Data as OrderDetail;
                if (result != null) {
                    MessageBox.Show("Lưu thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetLayout();
                }
                else
                {
                    MessageBox.Show("Lưu không thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                   
                }

            }
            catch (Exception ex) { 
                MessageBox.Show($"{ex.Message}", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void update() {
            ButtonSave.Click -= ButtonSave_Click;
            ButtonSave.Click += ButtonUpdate_Click;
            ButtonSave.Content = "udpate";
            ButtonSave.Width += 20;
            this.Window_Loaded();
        }
        private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txt_orderDetailID.Text, out int orderdetailID)) {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderdetailID)).Data as OrderDetail;
                if (orderDetail == null)
                {
                    MessageBox.Show("Không thấy sản phẩm cập nhật ", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    orderDetail.Address = txt_Address.Text;
                    orderDetail.Message = txt_Message.Text;
                    orderDetail.Status = (txt_Status.Text.Trim() == "0") ? false : true;
                    orderDetail.ProductUserHaveId = _userHaveID == 0 ? orderDetail.ProductUserHaveId : _userHaveID;

                   orderDetail.ProductUserWantId = _userWantID == 0 ? orderDetail.ProductUserWantId : _userWantID;
                    var result = await _orderDetailBusiness.updateOrderDetail(orderDetail);
                    if (result.Message == Const.SUCCESS_UPDATE_MSG)
                    {

                        MessageBox.Show("Lưu thành công ", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetLayout();
                        return;
                    }
               
                        MessageBox.Show("Lưu không thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
             
            }
         

        }


        private async void btn_SelectDtg(object sender, RoutedEventArgs e)
        {
            update();
            Button btn = sender as Button;


            if (!int.TryParse(btn.CommandParameter.ToString(), out int orderDetailID))
            {
                MessageBox.Show("không tìm thấy ID!!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;

                if (orderDetail == null)
                {
                    MessageBox.Show("không tìm thấy sản phẩm!!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var userHave = (await _userHaveBusiness.getinforUserHave(orderDetail.ProductUserHaveId)).Data as UserHave;
                var userWant = (await _userWantBusiness.getinforUserWant(orderDetail.ProductUserWantId)).Data as UserWant;
                txt_haveProductName.Text = userHave.Product.Name;
                txt_havequantityProduct.Text = userHave.Quantity.ToString();
                txt_Message.Text = orderDetail.Message;
                txt_wantProductName.Text = userWant.Product.Name;
                txt_wantQuantityProduct.Text = userWant.Quantity.ToString();
                txt_Address.Text = orderDetail.Address;
                txt_Status.Text = (orderDetail.Status == true) ? "1" : "0";
                txt_createCustommer.Text = userHave.Product.Customer.FullName;
                txt_orderDetailID.Text = orderDetail.OrderDetailId.ToString();

        }

        private async void ButtonUserHaveSmall_Click(object sender, RoutedEventArgs e)
        {
            SelectUserHave selectUserHave;
            if (string.IsNullOrEmpty(txt_orderDetailID.Text)|| "Empty" == txt_orderDetailID.Text)
            {
                selectUserHave =(_userWantID!=0)? new SelectUserHave(_loggedInCustomer, _userWantID) :new SelectUserHave(_loggedInCustomer);        
            }
            else {

                if (!int.TryParse(txt_orderDetailID.Text, out int orderTailID))
                {
                    MessageBox.Show("Vui lòng chọn thông tin giao dịch để update hoặc tạo 1 thông tin giao dịch mới", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderTailID)).Data as OrderDetail;
                selectUserHave = new SelectUserHave(_loggedInCustomer, orderDetail.ProductUserWantId, orderTailID);
               
            }
            selectUserHave.Show();
            this.Close();
        }

        private async void ButtonUserWantSmall_Click(object sender, RoutedEventArgs e)
        {
            SelectUserWant selectUserWant;
            if (string.IsNullOrEmpty(txt_orderDetailID.Text)|| "Empty" == txt_orderDetailID.Text)
            {
                selectUserWant =(_userHaveID!=0)?new SelectUserWant(_loggedInCustomer,_userHaveID):new SelectUserWant(_loggedInCustomer);
            }
            else {

                if (!int.TryParse(txt_orderDetailID.Text, out int orderTailID))
                {
                    MessageBox.Show("Vui lòng chọn thông tin giao dịch để update hoặc tạo 1 thông tin giao dịch mới", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderTailID)).Data as OrderDetail;
                selectUserWant = new SelectUserWant(_loggedInCustomer, orderDetail.ProductUserHaveId, orderTailID);
               
            }
            selectUserWant.Show();
            this.Close();
        }

        private async void btn_DeleteDtg(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (int.TryParse (btn.CommandParameter.ToString(),out int orderDetailID)) {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;
                orderDetail.Status=false;
                var result = await _orderDetailBusiness.updateOrderDetail(orderDetail);
                if (result.Data != null)
                {
                    MessageBox.Show("Xóa thành công ", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetLayout();
                    return;
                }
                else
                {
                    MessageBox.Show("xóa không thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            }


        }

    

       


        private void ButtonGoToOrder_Click(object sender, RoutedEventArgs e)
        {
            wWishList wWishListScreen = new wWishList(_loggedInCustomer);
            wWishListScreen.Show();
            this.Close();
        }
        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))

            {
                this.Window_Loaded();
                return;
            }

            var result = await _orderDetailBusiness.getAllMyOrderDetailByMessOrAdress(_loggedInCustomer.CustomerId,searchText );
            grdOrderView.ItemsSource = result.Data as List<OrderDetail>;
        }

        private async void Window_Loaded()
        {
            var result = await _orderDetailBusiness.getAllMyOrderDetail(_loggedInCustomer.CustomerId);

            if (result.Status > 0 && result.Data != null)
            {
                grdOrderView.ItemsSource = result.Data as List<OrderDetail>;
            }
            else
            {
                grdOrderView.ItemsSource = new List<OrderDetail>();
            }
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();


            ButtonSave.Click -= ButtonUpdate_Click;
            ButtonSave.Click += ButtonSave_Click;
            ButtonSave.Content = "Save";

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Window_Loaded();
        }


    }
}
 