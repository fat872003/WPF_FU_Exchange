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

namespace Exchange.WpfApp.SmallUI
{
    /// <summary>
    /// Interaction logic for wOrderInformation.xaml
    /// </summary>
    public partial class wOrderInformation : Window
    {
        private readonly OrderDetailBusiness orderDetailBusiness = new OrderDetailBusiness();
        private readonly OrderBusiness orderBusiness = new OrderBusiness(); 
        private readonly UserHaveBusiness userHaveBusiness = new UserHaveBusiness();
        private readonly UserWantBusiness userWantBusiness = new UserWantBusiness();

        public wOrderInformation(int orderDetailID)
        {
            InitializeComponent();
            renderInformation(orderDetailID);
        }

        private async void renderInformation(int orderDetailID) {
            var orderDetail = (await orderDetailBusiness.findOrderInformationById(orderDetailID)).Data as OrderDetail;
            var order = (await orderBusiness.findAOderByIdWithDetail((int)orderDetail.OrderId)).Data as Order;

            txtOrderID.Text = order.OrderId.ToString();
            txtOrderedDate.Text = order.OrderDate.ToString();
            txtCompleteDate.Text = order.CompleDate.ToString();
            txtOrderType.Text = order.OrderType.OrderTypeName;
            txtOrderNote.Text =order.Note;
            txtOrderDes.Text = order.Description;
            txtOrderDetailID.Text = orderDetailID.ToString();
            txtMessage.Text = orderDetail.Message;
            txtAddress.Text = orderDetail.Address;
            txtOrderdetailStatus.Text = (orderDetail.Status == true)?"khả dụng":"Không khả dụng";

            var userhave = (await userHaveBusiness.getinforUserHave(orderDetail.ProductUserHaveId)).Data as UserHave;
            txtUserHavetId.Text = userhave.ProductUserHaveId.ToString();
            txtUserHaveName.Text = userhave.Product.Name;
            txtUserHaveQuantity.Text = userhave.Quantity.ToString();
            txtUseHaveProductID.Text = userhave.ProductId.ToString();
            txtUserHaveDescription.Text = userhave.Description; 
            txtHaveGapPrice.Text = userhave.GapPrice.ToString();    
            txtHavecurrency.Text = userhave.Currency.ToString();
            txtHaveNote.Text = userhave.Note;
            txtHaveCreateDate.Text = userhave.CreateDate.ToString();    
            txtHaveFax.Text = userhave.Fax.ToString();
            txtCustomerHave.Text = userhave.Product.Customer.FullName;
            txtHaveStatus.Text = (userhave.Status == true) ? "khả dụng" : "không khả dụng";

            var userWant = (await userWantBusiness.getinforUserWant(orderDetail.ProductUserWantId)).Data as UserWant;
            txtUserWanttId.Text= userWant.ProductUserWantId.ToString();
            txtUserWantName.Text = userWant.Product.Name;
            txtUserWantQuantity.Text = userWant .Quantity.ToString();   
            txtUseWantProductID.Text = userWant.ProductId.ToString();
            txtUserWantDescription.Text = userWant.Description;
            txtWantGapPrice.Text= userWant.GapPrice.ToString(); 
            txtWantCurrency.Text= userWant .Currency.ToString();
            txtWantNote.Text = userWant.Note;
            txtWantCreateDate.Text = userWant.CreateDate.ToString();
            txtWantFax.Text = userWant.Fax.ToString();
            txtCustommerWant.Text = userWant.Product.Customer.FullName;
         txtWantedStatus.Text = (userWant.Status == true) ? "khả dụng" : "không khả dụng";

        }



        
    }
}
