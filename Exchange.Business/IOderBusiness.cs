using Exchange.Business.Base;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public interface IOderBusiness
    {
        Task<IBusinessResult> SearchByName(string name, int cus);
        Task<IBusinessResult> showAllMyoder(int id);
        Task<IBusinessResult> findAOderByIdWithDetail(int id);
        Task<IBusinessResult> saveAOrderInformation(Order order);
        Task<IBusinessResult> updateAOrderInformation(Order order);
        Task<IBusinessResult> removeAOrderInformation(Order order);

        Task<IBusinessResult> checkUserOfferProduct(int userHaveid);
        Task<IBusinessResult> checkUserTradedProduct(int userWantid);

        Task<IBusinessResult> UserOfferProductList(int cusID);
        Task<IBusinessResult> UserTradedProductList(int cusID);

    }
}
