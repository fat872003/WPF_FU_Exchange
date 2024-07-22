using Exchange.Business.Base;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public interface IUserWantBusiness
    {
        Task<IBusinessResult> getAllUserWantListByProductID(int productID);
        Task<IBusinessResult> getinforUserWant(int userWantID);
        Task<IBusinessResult> getinforUserWantList(int userWantID);
        Task<IBusinessResult> getinforUserWantListByDes(int userWantID, string des);
        Task<IBusinessResult> findMyWantProductById(int userHaveID);

        Task<IBusinessResult> addNewUSerWant(UserWant userWant);
        Task<IBusinessResult> UpdateUserWant(UserWant userWant);
        Task<IBusinessResult> removeMyWantProduct(UserWant userWant);
        Task<IBusinessResult> SearchByName(string name, int cus);
    }
}
