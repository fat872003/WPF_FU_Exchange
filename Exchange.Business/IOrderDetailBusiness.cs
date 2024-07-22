using Exchange.Business.Base;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public interface IOrderDetailBusiness
    {
        Task<IBusinessResult> getAllMyOrderDetail(int cusID);
        Task<IBusinessResult> getAllMyOrderDetailByMessOrAdress(int cusID,string name);
        Task<IBusinessResult> getInforOrderUserHaveProduct(int Oderid);
        Task<IBusinessResult> getInforOrderUserWantProduct(int Oderid);

        Task<IBusinessResult> removeOrderInformation(OrderDetail orderDetail);

        Task<IBusinessResult> findOrderInformationById(int orderDetailID);

        Task<IBusinessResult> saveOrderDetail(OrderDetail orderDetail);
       Task<IBusinessResult> getAllMyWishList(int cusID);
        Task<IBusinessResult> getAllMyWishListByMessAndAdress(int cusID,string name);
        Task<IBusinessResult> updateOrderDetail(OrderDetail orderDetail);

        Task<IBusinessResult> getAllMyOrder(int cusID);
        Task<IBusinessResult> getAllMyOrderByDesAndNote(int cusID, string name);
    }
}
