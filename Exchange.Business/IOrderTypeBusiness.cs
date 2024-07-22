using Exchange.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public interface IOrderTypeBusiness
    {
        Task<IBusinessResult> GetAllOrderType();
    }
}
