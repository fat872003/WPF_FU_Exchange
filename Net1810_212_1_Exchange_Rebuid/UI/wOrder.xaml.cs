using Exchange.Business;
using Exchange.Common;
using Exchange.Data.Models;
using Exchange.WpfApp.SmallUI;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
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
    /// Interaction logic for wOrder.xaml
    /// </summary>
    public partial class wOrder : Window
    {

        private readonly OrderBusiness _orderBusiness = new OrderBusiness();
        private readonly OrderDetailBusiness _orderDetailBusiness = new OrderDetailBusiness();
        private readonly ProductsBusiness productsBusiness = new ProductsBusiness();
        private readonly OrderTypeBusiness _orderTypeBusiness = new OrderTypeBusiness();
        private readonly UserHaveBusiness _userHaveBusiness = new UserHaveBusiness();
        private readonly UserWantBusiness _userWantBusiness = new UserWantBusiness();
       
        private Customer _loggedInCustomer;
        public wOrder()
        {
            InitializeComponent();
        }
        public wOrder(Customer customer)
        {

            InitializeComponent();
            _loggedInCustomer = customer;

        }



        private async void Window_Loaded()
        {
            var result = await _orderDetailBusiness.getAllMyOrder(_loggedInCustomer.CustomerId);
            if (result.Status > 0)
            {
                grdOrderView.ItemsSource = result.Data as List<OrderDetail>;
            }
            else
            {
                grdOrderView.ItemsSource = new List<OrderDetail>();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Window_Loaded();
        }

        //done
        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))

            {
                this.Window_Loaded();
                return;
            }

            var result = await _orderDetailBusiness.getAllMyOrderByDesAndNote(_loggedInCustomer.CustomerId, searchText);
            grdOrderView.ItemsSource = result.Data as List<OrderDetail>;

        }

        private void reload() {
            this.Close();
            wOrder wOrderScreen = new wOrder(_loggedInCustomer);
            wOrderScreen.Show();
        }


        private void resetLayout() {
            txt_orderID.Text = string.Empty;
            txt_orderDetailID.Text = string.Empty;
            txt_orderDate.Text = string.Empty;
            txt_completeDate.Text = string.Empty;
            txt_totalDiscount.Text = string.Empty;
            txt_totalOrderQuantity.Text = string.Empty;
            txt_Des.Text = string.Empty;
            OrderStatus.Text = string.Empty;
            txt_note.Text = string.Empty;
            txtUserHaveStatus.Text = string.Empty;
            txtUserWantStatus.Text = string.Empty;
            txtUserHaveStatus.IsReadOnly = true;
            txtUserWantStatus.IsReadOnly = true;
            this.Window_Loaded();

        }

        //done
        private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

            if ((int.TryParse(txt_orderID.Text, out int txt_orderIDint)) && (int.TryParse(txt_orderDetailID.Text, out int txt_orderDetailIDint)))
            {
                try
                {

                    var order = (await _orderBusiness.findAOderByIdWithDetail(txt_orderIDint)).Data as Order;

                    var selectedOrderTypeInt = (txtOrderType.SelectedItem as OrderType).OrderTypeId; // khai bao order type ma ng dung chon

                    var orderDetail = (await _orderDetailBusiness.findOrderInformationById(txt_orderDetailIDint)).Data as OrderDetail;
                    var userHave = (await _userHaveBusiness.getinforUserHave(orderDetail.ProductUserHaveId)).Data as UserHave;
                    var userWant = (await _userWantBusiness.getinforUserWant(orderDetail.ProductUserWantId)).Data as UserWant;
                    if (selectedOrderTypeInt == 1)
                    {
                        if (order.OrderTypeId == 2)
                        {
                            MessageBox.Show("giao dịch đã xác nhận thì không được về chưa xác nhận!!\n vui lòng hủy nếu như không muốn giao dịch nữa", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if (order.OrderTypeId == 3)
                        {
                            MessageBox.Show("Đơn hàng đã hoàn thành rồi không thể về chưa xác nhận được!!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (order.OrderTypeId == 4)
                        {
                            var result = MessageBox.Show("bạn có chắc chắn là thực hiện giao dịch không?", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.No)
                            {
                                return;
                            }
                        }
                    }
                    if (selectedOrderTypeInt == 2) // done
                    {
                        if (userHave.Product.CustomerId == _loggedInCustomer.CustomerId) // done
                        {
                            MessageBox.Show("bạn không được quyền thay đổi trạng thái xác nhận của giao dịch", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (userHave.Status == false)  // done
                        {
                            MessageBox.Show("Sản phẩm bên trao đổi đang không khả dụng", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (userWant.Status== false) //done
                        {
                            MessageBox.Show("Sản phẩm bên muốn đang không khả dụng", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (orderDetail.Status == false) //done
                        {
                            MessageBox.Show("thông tin giao dịch đang không khả dụng", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (order.UserHaveStatus == false) //done
                        {
                            MessageBox.Show($"Vui lòng đợi bên người muốn trao đổi xác nhận:{userHave.Product.Customer.FullName} !!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (order.UserWantStatus == false) //done
                        {
                            MessageBox.Show($"Vui lòng đợi bên người giữ hàng trao đổi xác nhận:{userWant.Product.Customer.FullName}!!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (order.OrderTypeId == 3) //done
                        {
                            MessageBox.Show("Giao dịch đã hoàn thành không thể nào chuyển về xác nhận được!!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if (order.OrderTypeId == 4) //done 
                        {
                            MessageBox.Show("Giao dịch đã bị hủy vui lòng chuyển sang chưa xác nhận để duyệt", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var result = MessageBox.Show("Bạn có chắc chắn xác nhận giao dịch không ?  \n giao dịch sẽ không được chuyển lại sang chưa xác nhận" +
                           "chỉ có thể hủy để hoàn thôi giao dịch", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.No)
                        {
                            return;
                        } 

                            var productUserHave = (await productsBusiness.findProductById(userHave.ProductId)).Data as Product;
                            var productUserWant = (await productsBusiness.findProductById((int)userWant.ProductId)).Data as Product;

                            productUserHave.Quantity = productUserHave.Quantity - userHave.Quantity;
                            var saveUserHaveProduct = await productsBusiness.UpdateAproduct(productUserHave);
                            if (saveUserHaveProduct.Status == Const.FAIL_UPDATE_CODE)
                            {
                                MessageBox.Show("thay đổi số lượng sản phẩm bên người có trao đổi thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }

                            productUserWant.Quantity = productUserWant.Quantity - userWant.Quantity;
                            var saveUserWantProduct = await productsBusiness.UpdateAproduct(productUserWant);
                            if (saveUserWantProduct.Status == Const.FAIL_UPDATE_CODE)
                            {
                                MessageBox.Show("thay đổi số lượng sản phẩm bên người muốn trao đổi thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }
                        
                    }
                    if (selectedOrderTypeInt == 3)  //done
                    {

                        if (userHave.Product.CustomerId == _loggedInCustomer.CustomerId) //done
                        {
                            MessageBox.Show("bạn không được quyền thay đổi trạng thái xác nhận của giao dịch", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (order.OrderTypeId != 2)   //done
                        {
                            MessageBox.Show("giao dich phải được xác nhận mới được hoàn thành", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }


                        order.CompleDate = DateTime.Now;
                    }
                    if (selectedOrderTypeInt == 4)
                    {
                        if (order.OrderTypeId == 3) //done
                        {
                            MessageBox.Show("Giao dịch đã hoàn thành không được hủy", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        var result = MessageBox.Show("Bạn có chắc chắn hủy giao dịch không ?", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }

                        if (order.OrderTypeId == 2) //done
                        { // hủy mà đã xác nhận thì trả lại quantity gốc 
                            var productUserHave = (await productsBusiness.findProductById(userHave.ProductId)).Data as Product;
                            var productUserWant = (await productsBusiness.findProductById((int)userWant.ProductId)).Data as Product;

                            productUserHave.Quantity = productUserHave.Quantity + userHave.Quantity;
                            var saveUserHaveProduct = await productsBusiness.UpdateAproduct(productUserHave);
                            if (saveUserHaveProduct.Status == Const.FAIL_UPDATE_CODE)
                            {
                                MessageBox.Show("thay đổi số lượng sản phẩm bên người có trao đổi thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }

                            productUserWant.Quantity = productUserWant.Quantity + userWant.Quantity;
                            var saveUserWantProduct = await productsBusiness.UpdateAproduct(productUserWant);
                            if (saveUserWantProduct.Status == Const.FAIL_UPDATE_CODE)
                            {
                                MessageBox.Show("thay đổi số lượng sản phẩm bên người muốn trao đổi thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }
                        }

                    }

                    Boolean statusDashBoardOrder = (OrderStatus.Text.Trim() == "0") ? false : true;
                    order.OrderTypeId =selectedOrderTypeInt;
                    order.Description = txt_Des.Text;
                    order.Note = txt_note.Text;
                    order.UserHaveStatus = (txtUserHaveStatus.Text.Trim() == "0") ? false : true;
                    order.UserWantStatus = (txtUserWantStatus.Text.Trim() == "0") ? false : true;
                    // thay doi total quanty nua
                    if (statusDashBoardOrder != orderDetail.Status) { //done
                        orderDetail.Status = statusDashBoardOrder;
                        order.TotalOrderQuantity = order.TotalOrderQuantity+1;
                    }
                  
                    var resultOrderDetail = await _orderDetailBusiness.updateOrderDetail(orderDetail);
                    var resultOrder = await _orderBusiness.updateAOrderInformation(order);
                    if (resultOrder.Status == Const.SUCCESS_UPDATE_CODE && resultOrderDetail.Status == Const.SUCCESS_UPDATE_CODE)
                    {
                        MessageBox.Show("Cập nhật thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
               
            }

        }

        

        //done
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            resetLayout();
        }


        // load order type
        private async void LoadOrderTypes(int orderTypeID)
        {
            var orderTypesList = (await _orderTypeBusiness.GetAllOrderType()).Data as List<OrderType>;
            txtOrderType.ItemsSource = orderTypesList;
            var selectedOrderType = orderTypesList.FirstOrDefault(o => o.OrderTypeId == orderTypeID);
            txtOrderType.SelectedItem = selectedOrderType;
        }


        //DONE
        private async void btn_SelectDtg(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (int.TryParse(btn.CommandParameter.ToString(), out int orderDetailID)) {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;
                var userHave = (await _userHaveBusiness.getinforUserHave(orderDetail.ProductUserHaveId)).Data as UserHave;
                var userWant = (await _userWantBusiness.getinforUserWant(orderDetail.ProductUserWantId)).Data as UserWant;
                if (userHave.Product.CustomerId == _loggedInCustomer.CustomerId) {
                    txtUserHaveStatus.IsReadOnly = false;
                   
                }
                if (userWant.Product.CustomerId == _loggedInCustomer.CustomerId) {
                    txtUserWantStatus.IsReadOnly = false;
                
                }

                txt_orderID.Text = orderDetail.OrderId.ToString();
                txt_orderDetailID.Text = orderDetailID.ToString();
                txt_orderDate.Text = orderDetail.Order.OrderDate.ToString();
                txt_completeDate.Text = orderDetail.Order.CompleDate.ToString();
                txt_totalDiscount.Text = orderDetail.Order.TotalDiscount.ToString();
                txt_totalOrderQuantity.Text = orderDetail.Order.TotalOrderQuantity.ToString();
                txt_Des.Text = orderDetail.Order.Description;
                OrderStatus.Text = (orderDetail.Status == true) ? "1" : "0";
                txt_note.Text = orderDetail.Order.Note.ToString();
                txtUserHaveStatus.Text = (orderDetail.Order.UserHaveStatus == true) ? "1" : "0";
                txtUserWantStatus.Text = (orderDetail.Order.UserWantStatus == true) ? "1" : "0";
              
                txtCustommerOrder.Text = userHave.Product.Customer.FullName;
                LoadOrderTypes((int)orderDetail.Order.OrderTypeId);
            }

        }

        private void btn_DetailDtg(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (int.TryParse(btn.CommandParameter.ToString(), out int orderDetailID))
            {
                wOrderInformation wOrderInformationScreen = new wOrderInformation(orderDetailID);
                wOrderInformationScreen.Show();
            }

        }


        //done
        private async void btn_DeleteDtg(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (int.TryParse(btn.CommandParameter.ToString(), out int orderDetailID)) {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;
                if (orderDetail.Status==false) { 
                    MessageBox.Show("Giao dịch đã hủy rồi !!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                // sua them ve totalquantity order
                var order = (await _orderBusiness.findAOderByIdWithDetail((int)orderDetail.OrderId)).Data as Order;
                if (order.OrderTypeId!=1)
                { //check trang thai de delete
                    MessageBox.Show("Giao dịch chưa xác nhận mới được xóa", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                orderDetail.Status = false;
                var resultOrderDetailSave = (await _orderDetailBusiness.updateOrderDetail(orderDetail)); // sua status
                order.TotalOrderQuantity = order.TotalOrderQuantity - 1; // tranh de no ve <0
                var resultOrderSave = await _orderBusiness.updateAOrderInformation(order);

                if (resultOrderDetailSave.Status == Const.SUCCESS_UPDATE_CODE&& resultOrderSave.Status== Const.SUCCESS_UPDATE_CODE)
                {
                    MessageBox.Show("Xóa thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    reload();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        //DONE
        private async void btn_AcceptDtg(object sender, RoutedEventArgs e)
        {
            var acceptNotify = MessageBox.Show("Bạn có chắc chắn đồng ý giao dịch không?", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (acceptNotify==MessageBoxResult.No) { 
             return;
            }

            Button button = (Button)sender;
            if (int.TryParse(button.CommandParameter.ToString(), out int OrderDetailId)) {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(OrderDetailId)).Data as OrderDetail;
                if (orderDetail.Status==false) { 
                     MessageBox.Show($"Giao dịch orderdetail ID: {orderDetail.OrderDetailId} không khả dụng", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    return;
                }
                var order = (await _orderBusiness.findAOderByIdWithDetail((int)orderDetail.OrderId)).Data as Order;
                if (order.OrderTypeId!=1) {
                    MessageBox.Show($"chỉ có thể chấp nhận giao dịch khi ở trạng thái: chưa xác nhận!", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    return;
                }
                var userHave = (await _userHaveBusiness.getinforUserHave(orderDetail.ProductUserHaveId)).Data as UserHave;
                var userWant = (await _userWantBusiness.getinforUserWant(orderDetail.ProductUserWantId)).Data as UserWant;
                if (userHave.Product.CustomerId==_loggedInCustomer.CustomerId) {
                    order.UserHaveStatus = true;
                }
                if (userWant.Product.CustomerId == _loggedInCustomer.CustomerId) {
                    order.UserWantStatus = true;    
                }
                var result = await _orderBusiness.updateAOrderInformation(order);
                if (result.Status == Const.SUCCESS_UPDATE_CODE)
                {
                    MessageBox.Show("chấp nhận thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.reload();
                }
                else
                {
                    MessageBox.Show("chấp nhận thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
           
        }



        //done
        private async void btn_DeniedDtg(object sender, RoutedEventArgs e)
        {
            var acceptNotify = MessageBox.Show("Bạn có chắc chắn từ chối giao dịch không?", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (acceptNotify == MessageBoxResult.No)
            {
                return;
            }

            Button button = (Button)sender;
            if (int.TryParse(button.CommandParameter.ToString(), out int OrderDetailId))
            {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(OrderDetailId)).Data as OrderDetail;
                if (orderDetail.Status == false)
                {
                    MessageBox.Show($"Giao dịch orderdetail ID: {orderDetail.OrderDetailId} không khả dụng", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    return;
                }
                var order = (await _orderBusiness.findAOderByIdWithDetail((int)orderDetail.OrderId)).Data as Order;
                if (order.OrderTypeId != 1)
                {
                    MessageBox.Show($"chỉ có thể chấp nhận giao dịch khi ở trạng thái: chưa xác nhận!", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    return;
                }
                var userHave = (await _userHaveBusiness.getinforUserHave(orderDetail.ProductUserHaveId)).Data as UserHave;
                var userWant = (await _userWantBusiness.getinforUserWant(orderDetail.ProductUserWantId)).Data as UserWant;
                if (userHave.Product.CustomerId == _loggedInCustomer.CustomerId)
                {
                    order.UserHaveStatus = false;
                }
                if (userWant.Product.CustomerId == _loggedInCustomer.CustomerId)
                {
                    order.UserWantStatus = false;
                }
                var result = await _orderBusiness.updateAOrderInformation(order);
                if (result.Status == Const.SUCCESS_UPDATE_CODE)
                {
                    MessageBox.Show("Từ chối thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.reload();
                }
                else
                {
                    MessageBox.Show("Từ chối thất bại", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

      
}

