using Exchange.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public interface ICustomerBusiness
    {

        Task<IBusinessResult> checkAcountLogin(string txtEmail, String txtPass);
        Task<IBusinessResult> GetById(int code);
    }
}
