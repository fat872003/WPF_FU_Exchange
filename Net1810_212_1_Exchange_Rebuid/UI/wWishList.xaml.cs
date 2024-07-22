using Exchange.Business;
using Exchange.Data.Models;
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
    /// Interaction logic for wWishList.xaml
    /// </summary>
    public partial class wWishList : Window
    {
        private readonly Customer _loggedInCustomer;
        private readonly OrderDetailBusiness _orderDetailBusiness = new OrderDetailBusiness();
        private readonly OrderBusiness _orderBusiness = new OrderBusiness();
        private static List<OrderDetail> orderDetailsToOrderMemory = new List<OrderDetail>();
        public wWishList(Customer customer)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            orderDetailsToOrderMemory.Clear();
        }
        private async void Window_Loaded()
        {
            var result = await _orderDetailBusiness.getAllMyWishList(_loggedInCustomer.CustomerId);

            if (result.Status > 0 && result.Data != null)
            {
                grdWishList.ItemsSource = result.Data as List<OrderDetail>;
            }
            else
            {
                grdWishList.ItemsSource = new List<OrderDetail>();
            }

        }
        private async void SearchWishListTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))

            {
                this.Window_Loaded();
                return;
            }

            var result = await _orderDetailBusiness.getAllMyWishListByMessAndAdress (_loggedInCustomer.CustomerId, searchText);
            grdWishList.ItemsSource = result.Data as List<OrderDetail>;
        }

        private async void btn_DeleteDtg(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            if (int.TryParse(btn.CommandParameter.ToString(), out int orderDetailID))
            {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;
                orderDetail.Status = false;
                var result = await _orderDetailBusiness.updateOrderDetail(orderDetail);
                if (result.Data != null)
                {
                    MessageBox.Show("Xóa thành công ", "thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Window_Loaded();
                    return;
                }
                else
                {
                    MessageBox.Show("xóa không thành công", "thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            }



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Window_Loaded();
        }

        private async void btn_AddDtg(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = ((Button)sender).CommandParameter;
                if (btn != null)
                {
                    if (int.TryParse(btn.ToString(), out int OrderDetailId))
                    {
                        var orderDetail = (await _orderDetailBusiness.findOrderInformationById(OrderDetailId)).Data as OrderDetail;

                        if (orderDetail != null)
                        {
                            // Kiểm tra nếu orderDetail đã tồn tại trong danh sách
                            if (!orderDetailsToOrderMemory.Any(od => od.OrderDetailId == orderDetail.OrderDetailId)) // linq
                            {
                                orderDetailsToOrderMemory.Add(orderDetail);

                                this.grdWantOrder_Loaded();

                                MessageBox.Show("Đã thêm OrderDetail thành công.");

                            }
                            else
                            {
                                MessageBox.Show("OrderDetail đã tồn tại trong danh sách.");
                            }
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void grdWantOrder_Loaded()
        {
            grdWantOrder.ItemsSource = null;
            grdWantOrder.ItemsSource = orderDetailsToOrderMemory;
        }

        private async void btnOrder(object sender, RoutedEventArgs e)
        {

            try
            {
                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    TotalDiscount = 0,
                    TotalOrderQuantity = orderDetailsToOrderMemory.Count,
                    Description = "Mong bạn trao đổi",
                    TotalPrice = 0,
                    Note = "vận chuyển an toàn",
                    UserHaveStatus = false,
                    UserWantStatus = false,
                    OrderTypeId =1
                };

                var result = await _orderBusiness.saveAOrderInformation(order);

                foreach (OrderDetail orderDetail in orderDetailsToOrderMemory)
                {
                    orderDetail.OrderId = order.OrderId;
                    var udpateStatus = (await _orderDetailBusiness.updateOrderDetail(orderDetail)).Data as OrderDetail;
                    if (udpateStatus == null)
                    {
                        MessageBox.Show($"Không lưu được giao dịch {orderDetail.OrderDetailId}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                }
              
                if (result.Data == null)
                {
                    MessageBox.Show("Không tạo được giao dịch", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var asking = MessageBox.Show($"Hoàn tất giao dịch\n", "thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (asking == MessageBoxResult.Yes)
                {

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                orderDetailsToOrderMemory.Clear();
                this.Window_Loaded();

            }

        }

        private void btnviewOrder(object sender, RoutedEventArgs e)
        {


            wOrder wOrderScreen = new wOrder(_loggedInCustomer);
            wOrderScreen.Show();
            this.Hide();

        }

        private async void btn_DeleteFromOrderDtg(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (int.TryParse(btn.CommandParameter.ToString(), out int orderDetailID))
            {
                if (orderDetailsToOrderMemory.Any(od => od.OrderDetailId== orderDetailID)) // linq
                {
                var orderDetail = (await _orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;

                    orderDetailsToOrderMemory.Remove(orderDetail);

                    this.grdWantOrder_Loaded();

                    MessageBox.Show("Đã xóa OrderDetail thành công.");

                }
                else
                {
                    MessageBox.Show("Đã xóa OrderDetail thất bại");
                }
            }

        }

    }
}
