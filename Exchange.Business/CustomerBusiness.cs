using Exchange.Business.Base;
using Exchange.Common;
using Exchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Business
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomerBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> checkAcountLogin(string txtEmail, string txtPass)
        {
            try
            {
                #region Business rule
                #endregion

                var custommer = await _unitOfWork.customerRepository.GetCustomerByEmailAndPassAsync(txtEmail, txtPass);
                if (custommer == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_CREATE_MSG, custommer);
                }

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);

            }
        }

        public async Task<IBusinessResult> GetById(int code)
        {
            try
            {
                var product = await _unitOfWork.customerRepository.GetByIdAsync(code);
                return product != null
                    ? new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, product)
                    : new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

    }
}
