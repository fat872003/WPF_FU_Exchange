using Exchange.Business.Base;
using Exchange.Common;
using Exchange.Data;
using Exchange.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public class OrderTypeBusiness : IOrderTypeBusiness
    {
        private UnitOfWork _unitOfWork;
        public OrderTypeBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAllOrderType()
        {
            try
            {
                #region Business rule
                #endregion

                var productUserHave = await _unitOfWork.orderTypeRepository.GetAllAsync();

                if (productUserHave == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, productUserHave);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
