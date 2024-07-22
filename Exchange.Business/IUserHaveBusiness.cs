using Exchange.Business.Base;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public interface IUserHaveBusiness
    {

        Task<IBusinessResult> findallHaveProductByProductId(int productID);
        Task<IBusinessResult> GetAllProductHomePage(int customerID);
        Task<IBusinessResult> SearchByName(string name, int cus);

        Task<IBusinessResult> getMyHaveProductList(int customerID);
        Task<IBusinessResult> getMyHaveProduct(int customerID);

        Task<IBusinessResult> UpdateMyHaveProduct(UserHave userHave);
        Task<IBusinessResult> getinforUserHave(int userHaveID);

        Task<IBusinessResult> SearchByNameMyUserHaveList(string name, int cus);
        Task<IBusinessResult> findMyHaveProductById(int userHaveID);
        Task<IBusinessResult> removeMyHaveProduct(UserHave userHave);
        Task<IBusinessResult> SearchByDesAndNoteMyUserHaveList(string name, int cus);
        Task<IBusinessResult> saveMyHaveProduct(UserHave userHave);

    }
}
